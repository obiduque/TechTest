namespace TechTest.Dto
{
    public class TaskFilter
    {
        public int? IdUser {  get; set; }
        public string? State { get; set; }
        public bool? Order { get; set; }
        public string? MetaKey { get; set; }
        public string? metaData { get; set; }
        public TaskFilter() { }
        public TaskFilter(int idUsuario, string estado, bool ordenado, string llave, string data)
        {
            IdUser = idUsuario;
            State = estado;
            Order = ordenado;
            MetaKey = llave;
            metaData = data;
        }
    }
}
