using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO;
using YerbaSoft.Web.Games.Clue.Common.DTO;
using YerbaSoft.Web.Games.Clue.Common.DTO.Clue;

namespace YerbaSoft.Web.Games.Clue.BLL
{
    public class ClueService : BaseService
    {
        /// <summary>
        /// Indica si éste jugador está jugando a éste Juego y debe ser redirigido al juego
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public bool IsUserInGame(Guid idUser)
        {
            return this.Session.Clue.Mesas.Any(p => p.HasUser(idUser)); // el usuario está jugando al juego desde que existe en una mesa
        }
        
        public DTO.Result<Common.DTO.Clue.MesasInfo> GetMesas(Guid idUser)
        {
            var mesas = this.Session.Clue.Mesas.Find(p => p.Status == Common.DTO.Clue.Mesa.MesaStatus.WaitingPlayers || p.Status == Common.DTO.Clue.Mesa.MesaStatus.Playing).ToArray();
            var current = mesas.SingleOrDefault(p => p.Integrantes.Any(i => i.Id == idUser));

            if (current != null && current.Status == Common.DTO.Clue.Mesa.MesaStatus.Playing)
                mesas = new Common.DTO.Clue.Mesa[] { current };    // se va a redirigir a la mesa (no se necesita la info de las otras mesas)

            // orden de las mesas (siempre primero la actual)
            mesas = mesas.OrderBy(p => p == current ? 1 : 2).ToArray();

            return new DTO.Result<Common.DTO.Clue.MesasInfo>(new Common.DTO.Clue.MesasInfo() { Mesas = mesas, Current = current });
        }

        public DTO.Result<Common.DTO.Clue.Mesa> CreateMesa(Guid idUser, int sillas, string tipoTableroName)
        {
            if (this.Session.Clue.Mesas.Find(m => m.Integrantes.Select(p => p.Id).Contains(idUser)).Any())
                return new DTO.Result<Common.DTO.Clue.Mesa>("Error al crear la mesa. Ya estás en otra mesa");

            var mesa = this.Session.Clue.Mesas.GetNew();
            mesa.Id = Guid.NewGuid();
            mesa.IdOwner = idUser;
            mesa.Sillas = sillas;
            mesa.Integrantes = this.Session.Users.Find(p => p.Id == idUser).ToList();
            mesa.Status = Common.DTO.Clue.Mesa.MesaStatus.WaitingPlayers;
            mesa.TipoTablero = this.Session.Clue.TipoTableros.Find(p => p.Name == tipoTableroName).Single();
            mesa = this.Session.Clue.Mesas.UpsertEntity(mesa);
            this.Session.Clue.Mesas.Commit();

            return new DTO.Result<Common.DTO.Clue.Mesa>(mesa);
        }

        public DTO.Result AbandonarMesa(Guid idUser)
        {
            var mesas = this.Session.Clue.Mesas.Find(p => p.Integrantes.Select(u => u.Id).Contains(idUser)).ToArray();

            foreach (var mesa in mesas)
            {
                var cierroMesa = false;
                if (mesa.IdOwner == idUser)
                {
                    if (mesa.Integrantes.Count > 1) // paso el lider
                    {
                        mesa.IdOwner = mesa.Integrantes.Where(p => p.Id != idUser).First().Id.Value;
                    }
                    else // Cierro la mesa
                    {
                        cierroMesa = true;
                    }
                }

                if (!cierroMesa)
                {
                    mesa.Integrantes.Remove(mesa.Integrantes.Single(p => p.Id == idUser));
                    this.Session.Clue.Mesas.UpsertEntity(mesa);
                }
                else
                {
                    this.Session.Clue.Mesas.DeleteEntity(mesa);
                }
            }

            this.Session.Clue.Mesas.Commit();

            return new DTO.Result(true);
        }

        public DTO.Result EnterMesa(Guid idUser, Guid idMesa)
        {
            var r = this.AbandonarMesa(idUser);
            if (r.ExistsErrorMessages) return r;

            var mesa = this.Session.Clue.Mesas.Find(p => p.Id == idMesa).Single();
            if (mesa.Integrantes.Count < mesa.Sillas || mesa.Status == Common.DTO.Clue.Mesa.MesaStatus.Playing)
            {
                mesa.Integrantes.Add(this.Session.Users.Find(p => p.Id == idUser).Single());
                this.Session.Clue.Mesas.UpsertEntity(mesa);
                this.Session.Clue.Mesas.Commit();
            }
            else
            {
                return new DTO.Result("Mesa está llena");
            }

            return new DTO.Result(true);
        }

        public DTO.Result StartMesa(Guid idUser, Guid idMesa)
        {
            var mesa = this.Session.Clue.Mesas.Find(p => p.Id == idMesa).Single();
            mesa.Status = Common.DTO.Clue.Mesa.MesaStatus.Playing;
            mesa.Sillas = mesa.Integrantes.Where(p => p != null).Count();
            this.Session.Clue.Mesas.UpsertEntity(mesa);
            this.Session.Clue.Mesas.Commit();

            // Inicializar el tablero
            var tablero = this.Session.Clue.Tableros.GetNew();
            tablero.Manager.StartTablero(mesa);
            this.Session.Clue.Tableros.UpsertEntity(tablero);
            this.Session.Clue.Tableros.Commit();

            // Inicializo las notas
            var notas = this.Session.Clue.Notas.GetNew();
            notas.Inicializar(tablero);
            this.Session.Clue.Notas.UpsertEntity(notas);
            this.Session.Clue.Notas.Commit();


            return new DTO.Result(true);
        }

        public DTO.Result<string[]> GetTipoTableroNames(Guid idUser)
        {
            return new DTO.Result<string[]>(this.Session.Clue.TipoTableros.Find().Select(p => p.Name).ToArray());
        }

        public DTO.Result<Common.DTO.Clue.GameInfo> GetGameInfo(Guid idUser)
        {
            var mesa = this.Session.Clue.Mesas.Find(p => p.Integrantes.Select(u => u.Id).Contains(idUser) && p.Status == Common.DTO.Clue.Mesa.MesaStatus.Playing).SingleOrDefault();

            if (mesa == null)
                return new DTO.Result<Common.DTO.Clue.GameInfo>("Error al obtener la mesa de juego. Actualice el juego");

            var tablero = GetTablero(mesa.Id);
            if (tablero.ExistsErrorMessages)
                return new DTO.Result<Common.DTO.Clue.GameInfo>(tablero.Messages);

            return new DTO.Result<Common.DTO.Clue.GameInfo>(new Common.DTO.Clue.GameInfo() { Mesa = mesa, Tablero = tablero.Data });
        }

        public DTO.Result<Common.DTO.Clue.Tablero> GetTablero(Guid idMesa)
        {
            return new DTO.Result<Common.DTO.Clue.Tablero>(this.Session.Clue.Tableros.Find(p => p.IdMesa == idMesa).Single());
        }
        
        public DTO.Result LeftGame(User user)
        {
            var mesas = this.Session.Clue.Mesas.Find(p => p.Integrantes.Select(i => i.Id).Contains(user.Id));
            foreach (var mesa in mesas)
            {
                mesa.Integrantes = mesa.Integrantes.Where(p => p.Id != user.Id).ToList();
                this.Session.Clue.Mesas.UpsertEntity(mesa);
            }
            this.Session.Clue.Mesas.Commit();

            return new DTO.Result(true);
        }

        public DTO.Result MoveTo(Guid idUser, string x, string y)
        {
            var mesa = this.Session.Clue.Mesas.Find(p => p.HasUser(idUser)).Single();
            var tablero = this.Session.Clue.Tableros.Find(p => p.IdMesa == mesa.Id).Single();

            tablero.Manager.MoverPersonaje(mesa, x + y);

            this.Session.Clue.Tableros.UpsertEntity(tablero);
            this.Session.Clue.Tableros.Commit();
            return new DTO.Result();
        }

        public DTO.Result SelectNoCard(Guid idUser, string statusCode)
        {
            var status = (Common.DTO.Clue.TurnoStatus)Enum.Parse(typeof(Common.DTO.Clue.TurnoStatus), statusCode);

            var mesa = this.Session.Clue.Mesas.Find(p => p.HasUser(idUser)).Single();
            var tablero = this.Session.Clue.Tableros.Find(p => p.IdMesa == mesa.Id).Single();

            tablero.Manager.SelectNoCard(idUser, mesa, status);

            this.Session.Clue.Tableros.UpsertEntity(tablero);
            this.Session.Clue.Tableros.Commit();
            return new Result();
        }

        public DTO.Result UseCard(Guid idUser, Card card, Card.DataStr data)
        {
            var mesa = this.Session.Clue.Mesas.Find(p => p.HasUser(idUser)).Single();
            var tablero = this.Session.Clue.Tableros.Find(p => p.IdMesa == mesa.Id).Single();

            tablero.Manager.UseCard(idUser, mesa, card, data);

            this.Session.Clue.Tableros.UpsertEntity(tablero);
            this.Session.Clue.Tableros.Commit();
            return new Result();
        }

        #region Notas

        public Result<Nota[]> GetNotas(Guid idUser)
        {
            var mesa = this.Session.Clue.Mesas.Find(p => p.HasUser(idUser)).Single();
            var tablero = this.Session.Clue.Tableros.Find(p => p.IdMesa == mesa.Id).Single();
            var notas = this.Session.Clue.Notas.Find(p => p.IdTablero == tablero.Id).Single();

            var index = tablero.Turnos.IndexOf(p => p == idUser);
            return new Result<Nota[]>(notas.JugadorNotas[index].ToArray());
        }

        public Result RemoveNota(Guid idUser, Nota nota)
        {
            var mesa = this.Session.Clue.Mesas.Find(p => p.HasUser(idUser)).Single();
            var tablero = this.Session.Clue.Tableros.Find(p => p.IdMesa == mesa.Id).Single();
            var notas = this.Session.Clue.Notas.Find(p => p.IdTablero == tablero.Id).Single();
            var index = tablero.Turnos.IndexOf(p => p == idUser);

            var dbNota = notas.JugadorNotas[index].SingleOrDefault(p => p.TipoRumor == nota.TipoRumor && p.RumorCode == nota.RumorCode && p.Jugador == nota.Jugador);

            foreach(var simbolo in nota.Simbolos)
            {
                if (dbNota.Simbolos.Any(p => p == simbolo))
                    dbNota.Simbolos.Remove(simbolo);
            }

            return new Result();
        }

        public Result AddNota(Guid idUser, Nota nota)
        {
            var mesa = this.Session.Clue.Mesas.Find(p => p.HasUser(idUser)).Single();
            var tablero = this.Session.Clue.Tableros.Find(p => p.IdMesa == mesa.Id).Single();
            var notas = this.Session.Clue.Notas.Find(p => p.IdTablero == tablero.Id).Single();
            var index = tablero.Turnos.IndexOf(p => p == idUser);

            var dbNota = notas.JugadorNotas[index].SingleOrDefault(p => p.TipoRumor == nota.TipoRumor && p.RumorCode == nota.RumorCode && p.Jugador == nota.Jugador);

            foreach (var simbolo in nota.Simbolos)
            {
                if (!dbNota.Simbolos.Any(p => p == simbolo))
                {
                    dbNota.Simbolos.Add(simbolo);
                }
            }

            return new Result();
        }

        #endregion
    }
}
