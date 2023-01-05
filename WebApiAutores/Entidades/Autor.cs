namespace WebApiAutores.Entidades
{
    public class Autor
    {
        public int Id { get; set; }
        public String Nombre { get; set; }

        //para cargar los libros de un autor
        public List<Libro> Libros {get; set;}
    }
}
