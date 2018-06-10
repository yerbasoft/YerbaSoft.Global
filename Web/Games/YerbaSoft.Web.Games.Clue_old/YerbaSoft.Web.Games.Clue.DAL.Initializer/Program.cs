using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Web.Games.Clue.DAL.Initializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Session("W:\\YerbaSoft\\Web\\Games\\YerbaSoft.Web.Games.Config.xml", "");

            var game = s.Game.Find(p => p.Id == new Guid("00000000-0000-0000-0001-000000000000")).SingleOrDefault();
            if (game == null)
                game = s.Game.GetNew();

            game.Codigo = "Clue";
            game.Descripcion = "El clue es un juego basado en el Cluedo, a su vez basado en el Espionaje. <a class=\"btn btn-default\" href=\"https://es.wikipedia.org/wiki/Cluedo\">Ver más &raquo;</a>";
            game.Id = new Guid("00000000-0000-0000-0001-000000000000");
            game.Nombre = "Clue";
            s.Game.UpsertEntity(game);

            var admin = s.Usuario.Find(p => p.Id == new Guid("00000000-0000-0000-0000-000000000001")).SingleOrDefault();
            if (admin == null)
                admin = s.Usuario.GetNew();
            admin.Id = new Guid("00000000-0000-0000-0000-000000000001");
            admin.Login = "admin";
            admin.Logo = "man.jpg";
            admin.Nombre = "Admin";
            admin.Password = "admin";
            admin.Sexo = 'M';
            s.Usuario.UpsertEntity(admin);

            var bot1 = s.Usuario.Find(p => p.Id == new Guid("00000000-0000-0000-0000-000000000011")).SingleOrDefault();
            if (bot1 == null)
                bot1 = s.Usuario.GetNew();
            bot1.Id = new Guid("00000000-0000-0000-0000-000000000011");
            bot1.Login = "bot";
            bot1.Logo = "robot.jpg";
            bot1.Nombre = "Bot";
            bot1.Password = "bot";
            bot1.Sexo = 'M';
            s.Usuario.UpsertEntity(bot1);

            var bot2 = s.Usuario.Find(p => p.Id == new Guid("00000000-0000-0000-0000-000000000012")).SingleOrDefault();
            if (bot2 == null)
                bot2 = s.Usuario.GetNew();
            bot2.Id = new Guid("00000000-0000-0000-0000-000000000012");
            bot2.Login = "bothard";
            bot2.Logo = "robot.jpg";
            bot2.Nombre = "Bot Dificil";
            bot2.Password = "bothard";
            bot2.Sexo = 'M';
            s.Usuario.UpsertEntity(bot2);
            
            s.Commit();
        }
    }
}
