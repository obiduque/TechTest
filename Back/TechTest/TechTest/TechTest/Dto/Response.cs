namespace TechTest.Dto
{
    public class Response
    {
        public int? Status {  get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
        public Response(int estado, string mensaje, object datos)
        {
            Status = estado;
            Message = mensaje;
            Data = datos;
        }
    }
}
