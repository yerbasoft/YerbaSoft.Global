using System;
using System.Collections.Generic;
using System.Linq;

namespace SIR.Common.DTO
{
    public class ResponseMessage
    {
        /// <summary>
        /// Excepción que generó el mensaje
        /// </summary>
        public Exception Ex { get; set; }
        /// <summary>
        /// Texto descriptivo del mensaje
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Indica si el mensaje es un error (true) o sólo un mensaje (false)
        /// </summary>
        public bool EsError { get; set; }

        public object Tag { get; set; }

        public ResponseMessage() { }
        public ResponseMessage(string mensaje) : this(mensaje, false, null, null) { }
        public ResponseMessage(string mensaje, bool esError) : this(mensaje, esError, null, null) { }
        public ResponseMessage(Exception ex) : this(null, true, ex, null) { }
        public ResponseMessage(string msg, bool esError, Exception ex, object tag)
        {
            this.EsError = esError;
            this.Ex = ex;
            this.Text = (ex != null && msg == null) ? ex.GetFullDescription() : msg;
            this.Tag = tag;
        }

        public ResponseMessage SetTag(object tag)
        {
            this.Tag = tag;
            return this;
        }

        public override string ToString()
        {
            return this.Text ?? this.Ex?.Message ?? base.ToString();
        }
    }

    public class ResponseMessageList : List<ResponseMessage>
    {
        /// <summary>
        /// Agrega un nuevo mensaje
        /// </summary>
        /// <param name="mensaje">mensaje</param>
        /// <param name="esError">indica si es un error</param>
        /// <returns></returns>
        public ResponseMessageList Add(string mensaje, bool esError)
        {
            this.Add(new ResponseMessage(mensaje, esError));
            return this;
        }
        /// <summary>
        /// Agrega un nuevo error desde una Excepcion
        /// </summary>
        /// <param name="ex">Excepción</param>
        /// <returns></returns>
        public ResponseMessageList AddError(Exception ex)
        {
            this.Add(new ResponseMessage(ex));
            return this;
        }
        /// <summary>
        /// Agrega un mensaje
        /// </summary>
        /// <param name="mensaje">mensaje</param>
        /// <returns></returns>
        public ResponseMessageList AddMessage(string mensaje)
        {
            this.Add(new ResponseMessage(mensaje));
            return this;
        }
        /// <summary>
        /// Agrega un mensaje de error
        /// </summary>
        /// <param name="mensaje">mensaje</param>
        /// <returns></returns>
        public ResponseMessageList AddError(string mensaje)
        {
            this.Add(new ResponseMessage(mensaje, true));
            return this;
        }

        public override string ToString()
        {
            return $"Mensajes: {this.Count(p => !p.EsError)} Errores: {this.Count(p => p.EsError)}";
        }
    }

    public class Response
    {
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
        public ResponseMessageList Messages = new ResponseMessageList();

        public Response() { }
        public Response(bool success) : this(success, null, false, null) { }
        public Response(string error) : this(false, error, true, null) { }
        public Response(string mensaje, bool esError) : this(!esError, mensaje, esError, null) { }
        public Response(Exception ex) : this(false, null, true, ex) { }
        public Response(bool success, string mensaje, bool esError, Exception ex)
        {
            this.Success = success;

            if (!string.IsNullOrEmpty(mensaje))
                this.Messages.Add(mensaje, esError);
            if (ex != null)
                this.Messages.AddError(ex);
        }
        public Response(Response res) : this(res.Messages) { }
        public Response(ResponseMessage mensajes) : this(new ResponseMessageList() { mensajes }) { }
        public Response(ResponseMessageList list)
        {
            this.Success = !(list?.Any(p => p.EsError) ?? false);

            if (list != null)
                this.Messages.AddRange(list);
        }

        /// <summary>
        /// Agrega un mensaje de error y cambia el Success a False
        /// </summary>
        public Response AddError(string mensaje)
        {
            this.Success = false;
            this.Messages.AddError(mensaje);
            return this;
        }
        /// <summary>
        /// Agrega un error y cambia el Success a False
        /// </summary>
        public Response AddError(Exception ex)
        {
            this.Success = false;
            this.Messages.AddError(ex);
            return this;
        }
        /// <summary>
        /// Agrega una lista de mensajes de error
        /// </summary>
        public Response AddError(ResponseMessageList messageList)
        {
            if (messageList == null)
                return this;

            Success = false;
            Messages.AddRange(messageList);
            return this;
        }

        public Response Add(Response res)
        {
            if (res?.Messages != null)
                this.Messages.AddRange(res.Messages);

            return this;
        }
    }

    public class Response<T> : Response
    {
        /// <summary>
        /// Objeto de retorno
        /// </summary>
        public virtual T Data { get; set; }

        public Response() { }
        public Response(T data) : base(true)
        {
            this.Data = data;
        }
        public Response(bool success) : base(success, null, false, null) { }
        public Response(string error) : base(false, error, true, null) { }
        public Response(string mensaje, bool esError) : base(!esError, mensaje, esError, null) { }
        public Response(Exception ex) : base(false, null, true, ex) { }
        public Response(bool success, string mensaje, bool esError, Exception ex) : base(success, mensaje, esError, ex) { }
        public Response(Response res) : base(res.Messages) { }
        public Response(ResponseMessage mensajes) : base(new ResponseMessageList() { mensajes }) { }
        public Response(ResponseMessageList list) : base(list) { }

        public Response<T> SetData(T data)
        {
            this.Data = data;
            return this;
        }

        /// <summary>
        /// Agrega un mensaje de error y cambia el Success a False
        /// </summary>
        public new Response<T> AddError(string mensaje)
        {
            base.AddError(mensaje);
            return this;
        }
        /// <summary>
        /// Agrega un error y cambia el Success a False
        /// </summary>
        public new Response<T> AddError(Exception ex)
        {
            base.AddError(ex);
            return this;
        }
        /// <summary>
        /// Agrega una lista de mensajes de error
        /// </summary>
        public new Response<T> AddError(ResponseMessageList messageList)
        {
            base.AddError(messageList);
            return this;
        }

        public new Response<T> Add(Response res)
        {
            base.Add(res);
            return this;
        }
    }
}
