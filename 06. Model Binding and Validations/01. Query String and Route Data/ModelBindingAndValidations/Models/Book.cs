namespace ModelBindingAndValidations.Models
{
    public class Book
    {
        public int? Bookid {  get; set; }
        public string Author {  get; set; }

        public override string ToString()
        {
            return $"Book object - Book id {Bookid} - Author: {Author}";
        }
    }
}
