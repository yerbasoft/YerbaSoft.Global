using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.DTO
{
    /// <summary>
    /// Resultado de una operación
    /// </summary>
    public class Result
    {
        #region Message Class

        /// <summary>
        /// Representa un mensaje de retorno
        /// </summary>
        public class Message
        {
            /// <summary>
            /// Excepción que generó el error
            /// </summary>
            internal System.Exception Ex { get; set; }
            /// <summary>
            /// Texto descriptivo del mensaje
            /// </summary>
            public string Text { get; set; }
            /// <summary>
            /// Indica si el mensaje es un error (true) o sólo un mensaje (false)
            /// </summary>
            public bool EsError { get; set; }

            public Message() { }
            public Message(string mensaje)
            {
                this.Text = mensaje;
            }
            public Message(string mensaje, bool esError)
            {
                this.Text = mensaje;
                this.EsError = esError;
            }
            public Message(System.Exception ex)
            {
                this.Ex = ex;
                this.Text = Exceptions.Exceptions.GetErrorFullDescription(ex, new Exceptions.ExceptionConvertTemplateLight());
                this.EsError = true;
            }
        }

        #endregion

        #region MessageList Class

        /// <summary>
        /// Lista de mensajes
        /// </summary>
        public class MessageList : List<Message>
        {
            protected Result Parent;

            private MessageList() { }
            internal MessageList(Result parent)
            {
                this.Parent = parent;
            }

            /// <summary>
            /// Agrega un nuevo mensaje
            /// </summary>
            /// <param name="mensaje">mensaje</param>
            /// <param name="esError">indica si es un error</param>
            /// <returns></returns>
            public MessageList Add(string mensaje, bool esError)
            {
                this.Add(new Message(mensaje, esError));
                if (esError)
                    this.Parent.Success = false;

                return this;
            }
            /// <summary>
            /// Agrega un nuevo error desde una Excepcion
            /// </summary>
            /// <param name="ex">Excepción</param>
            /// <returns></returns>
            public MessageList AddError(System.Exception ex)
            {
                this.Add(new Message(ex));
                this.Parent.Success = false;

                return this;
            }
            /// <summary>
            /// Agrega un mensaje
            /// </summary>
            /// <param name="mensaje">mensaje</param>
            /// <returns></returns>
            public MessageList AddMessage(string mensaje)
            {
                this.Add(new Message(mensaje));
                return this;
            }
            /// <summary>
            /// Agrega un mensaje de error
            /// </summary>
            /// <param name="mensaje">mensaje</param>
            /// <returns></returns>
            public MessageList AddError(string mensaje)
            {
                this.Add(new Message(mensaje, true));
                this.Parent.Success = false;

                return this;
            }
            /// <summary>
            /// Agrega una lista de mensajes de error
            /// </summary>
            /// <param name="messageList">lista de mensajes</param>
            public MessageList Add(MessageList messageList)
            {
                foreach (var m in messageList)
                {
                    this.Add(m);
                    if (m.EsError)
                        this.Parent.Success = false;
                }

                return this;
            }

            /// <summary>
            /// Muestra de Mensajes de error
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return ToString(new Exceptions.ExceptionConvertTemplateLight());
            }
            public string ToString(Exceptions.ExceptionConvertTemplateBase config)
            {
                var sb = new StringBuilder();

                foreach (var m in this)
                {
                    sb.AppendLine(string.Format("{0}: {1}", 
                        m.EsError ? "ERROR" : "INFO", 
                        m.Ex != null ? config.GetFullDescription(m.Ex, null) : m.Text
                        ));
                }

                return sb.ToString();
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Indica si la operación resultó exitosa
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Indica si existe algún mensaje de error
        /// </summary>
        public bool ExistsErrorMessages
        {
            get { return this.Messages.Where(p => p.EsError).Any(); }
        }

        /// <summary>
        /// Lista de Mensajes
        /// </summary>
        public MessageList Messages { get; protected set; }

        #endregion

        #region Constructor

        public Result()
        {
            this.Messages = new MessageList(this);
        }
        public Result(bool success)
            : this()
        {
            this.Success = success;
        }
        public Result(string error)
            : this()
        {
            this.Messages.AddError(error);
            this.Success = false;
        }
        public Result(string mensaje, bool esError)
            : this()
        {
            this.Messages.Add(mensaje, esError);
            this.Success = !esError;
        }
        public Result(System.Exception ex)
            : this()
        {
            this.Messages.AddError(ex);
            this.Success = false;
        }
        public Result(MessageList messageList)
            : this()
        {
            if (messageList == null || messageList.Count < 1)
            {
                this.Success = true;
            }
            else
            {
                this.Messages = messageList;
                this.Success = false;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Agrega un mensajes
        /// </summary>
        /// <param name="messageList"></param>
        public Result Add(Message message)
        {
            this.Messages.Add(message);
            return this;
        }
        /// <summary>
        /// Agrega una lista de mensajes
        /// </summary>
        /// <param name="messageList"></param>
        public Result Add(MessageList messageList)
        {
            this.Messages.Add(messageList);
            return this;
        }
        /// <summary>
        /// Agrega un mensaje de error y cambia el Success a False
        /// </summary>
        /// <param name="p"></param>
        public Result AddError(string mensaje)
        {
            this.Messages.AddError(mensaje);
            return this;
        }
        /// <summary>
        /// Agrega un mensaje de error y cambia el Success a False
        /// </summary>
        /// <param name="p"></param>
        public Result AddError(System.Exception ex)
        {
            this.Messages.AddError(ex);
            return this;
        }
        /// <summary>
        /// Devuelve las excepciones no controladas encontradas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<System.Exception> GetExceptions()
        {
            return this.Messages.Where(p => p.Ex != null).Select(p => p.Ex);
        }

        #endregion
    }

    /// <summary>
    /// Resultado tipado de una operación
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T> : Result
    {
        #region Properties

        /// <summary>
        /// Objeto de retorno
        /// </summary>
        public virtual T Data { get; set; }

        #endregion

        #region Constructor

        public Result() : base() { }
        public Result(bool success) : base(success) { }
        public Result(string error) : base(error) { }
        public Result(string mensaje, bool esError) : base(mensaje, esError) { }
        public Result(Exception ex) : base(ex) { }
        public Result(MessageList messageList) : base(messageList) { }
        public Result(T data)
            : base(data != null)
        {
            this.Data = data;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Establece el dato tipado de resultado
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Result<T> SetData(T data)
        {
            this.Data = data;
            return this;
        }

        #endregion
    }

    /// <summary>
    /// Resultado doble tipado de una operación
    /// </summary>
    /// <typeparam name="T">tipo del primer resultado</typeparam>
    /// <typeparam name="U">tipo del segundo resultado</typeparam>
    public class Result<T1, T2> : Result
    {
        #region Properties

        /// <summary>
        /// Primer objeto de retorno
        /// </summary>
        public virtual T1 Data1 { get; set; }

        /// <summary>
        /// Segundo objeto de retorno
        /// </summary>
        public virtual T2 Data2 { get; set; }

        #endregion

        #region Constructor

        public Result() : base() { }
        public Result(bool success) : base(success) { }
        public Result(string error) : base(error) { }
        public Result(string mensaje, bool esError) : base(mensaje, esError) { }
        public Result(Exception ex) : base(ex) { }
        public Result(MessageList messageList) : base(messageList) { }
        public Result(T1 data1, T2 data2) : base(data1 != null && data2 != null)
        {
            this.Data1 = data1;
            this.Data2 = data2;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Establece los datos tipados de resultado
        /// </summary>
        /// <param name="data1">primer dato de retorno</param>
        /// <param name="data2">segundo dato de retorno</param>
        /// <returns></returns>
        public Result<T1, T2> SetData(T1 data1, T2 data2)
        {
            this.Data1 = data1;
            this.Data2 = data2;
            return this;
        }

        #endregion
    }

    /// <summary>
    /// resultado de una operación que devuelve una lista paginada de objetos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PaginedResult<T> : Result<IEnumerable<T>>
    {
        #region Properties

        /// <summary>
        /// Numero de pagina
        /// </summary>
        public int PageNum { get; set; }
        /// <summary>
        /// tamaño de rows por página
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// total de registros (sin paginado)
        /// </summary>
        public int TotalCount { get; set; }

        #endregion

        #region Constructor

        public PaginedResult() : base() { }
        public PaginedResult(bool success) : base(success) { }
        public PaginedResult(string error) : base(error) { }
        public PaginedResult(string mensaje, bool esError) : base(mensaje, esError) { }
        public PaginedResult(Exception ex) : base(ex) { }
        public PaginedResult(MessageList messageList) : base(messageList) { }
        public PaginedResult(IEnumerable<T> data) : base(data) { }
        public PaginedResult(IEnumerable<T> data, int pageNum, int pageSize, int totalCount)
            : base(data)
        {
            this.PageNum = pageNum;
            this.PageSize = pageSize;
            this.TotalCount = totalCount;
        }

        #endregion
    }
}