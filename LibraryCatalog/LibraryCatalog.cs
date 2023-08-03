class Library{

    public string? Name{
       get;set;
    }
    public string? Address{
       get;set;
    }
    
    public List<Book> BookList = new List<Book>();
    public List<MediaItem> MediaItemList = new List<MediaItem>();

    public void AddBook(Book BookToBeAdded){
        BookList.Add(BookToBeAdded);
    }

    public Book RemoveBook(Book BookToBeRemoved){
        BookList.Remove(BookToBeRemoved);
        return BookToBeRemoved;
    }
    public void AddMediaItem(MediaItem MediaItemToBeAdded){
        MediaItemList.Add(MediaItemToBeAdded);
    }

    public MediaItem RemoveMediaItem(MediaItem MediaItemToBeRemoved){
        MediaItemList.Remove(MediaItemToBeRemoved);
        return MediaItemToBeRemoved;
    }

    public void PrintCatalog(){
        Console.WriteLine("List of Books in The Library");
    
        foreach(Book book in BookList){
            this.PrintBook(book);
        }

        Console.WriteLine("List of MediaItems in The Library");

        foreach(MediaItem media in MediaItemList){
            this.printMediaItem(media);
        }
    }

    public Book SearchByBookTitle(string BookTitle){
            Book result = new Book("","","",0);
            foreach(Book book in BookList){
                if(BookTitle == book.Title){
                    return book;
                }
            }
            return result;


    }
    public Book SearchByAuthor(string BookAuthor){
            Book result = new Book("","","",0);
            foreach(Book book in BookList){
                if(BookAuthor == book.Author){
                    return book;
                }
            }
            return result;


    }
    public Book SearchByISBN(string BookISBN){
            Book result = new Book("","","",0);
            foreach(Book book in BookList){
                if(BookISBN == book.ISBN){
                    return book;
                }
            }
            return result;


    }
    public MediaItem SearchByMediaTitle(string MediaTitle){
            MediaItem result = new MediaItem("","",0);
            foreach(MediaItem item in MediaItemList){
                if(MediaTitle == item.Title){
                    return item;
                }
            }
            return result;


    }
    public MediaItem SearchByMediaType(string MediaTypeArg){
            MediaItem result = new MediaItem("","",0);
            foreach(MediaItem item in MediaItemList){
                if(MediaTypeArg == item.MediaType){
                    return item;
                }
            }
            return result;


    }

    public void PrintBook(Book book){
            Console.WriteLine($"Title ---- {book.Title}");
            Console.WriteLine($"Author ---- {book.Author}");
            Console.WriteLine($"ISBN ---- {book.ISBN}");
            Console.WriteLine($"PublicationYear ---- {book.PublicationYear}");
        
    }

    public void printMediaItem(MediaItem media){
            Console.WriteLine($"Title ---- {media.Title}");
            Console.WriteLine($"MediaTyep ---- {media.MediaType}");
            Console.WriteLine($"Duration ---- {media.Duration}");
            Console.WriteLine("/////////////////////////////////////////////////////////////");
    }

}

class Book{
    private string? title;
    private string? author;
    private string? isbn;
    private int? publicationYear;

    public Book(string title,string author,string isbn,int publicationYear){
        this.title = title;
        this.author = author;
        this.isbn = isbn;
        this.publicationYear = publicationYear;

    }

    public string Title {
        get{ return title!;} set{title = value;}
    }
    public string Author {
        get{ return author!;} set{author = value;}
    }
    public string ISBN {
        get{ return isbn!;} set{isbn = value;}
    }
    public int PublicationYear {
        get{ return (int)publicationYear!;} set{publicationYear = value;}
    }

    


}

class MediaItem{
    private String? title;
    private string? mediaType;
    private int duration;

    public MediaItem(string title,string mediaType,int duration){
        this.title = title;
        this.mediaType = mediaType;
        this.duration = duration;
    }

    public string Title {
        get { return title!;} set{ title = value;}
    }
    public string MediaType {
        get { return mediaType!;} set{ mediaType = value;}
    }
    public int Duration {
        get { return duration!;} set{ duration = value;}
    }

}


class Driver{

    public static void Main(){
        // Create a library object
       Library AAiTLibrary  = new Library();
       AAiTLibrary.Name = "AAiT";
       AAiTLibrary.Address = "Addis Ababa";

        // Create books
        Book CleanCode = new Book("Clean code","jhon doe","1111",2000);
        Book GrandDesign = new Book("Grand Design","jhon doe","2222",2001);

        // create media items
        MediaItem MediaItem1 = new MediaItem("Media Item 1","CD",60);
        MediaItem MediaItem2 = new MediaItem("Media Item 2","DVD",50);

        AAiTLibrary.AddBook(CleanCode);
        AAiTLibrary.AddBook(GrandDesign);
        AAiTLibrary.AddMediaItem(MediaItem1);
        AAiTLibrary.AddMediaItem(MediaItem2);
        AAiTLibrary.PrintCatalog();

        string Choice;
        List<string> SearchList = new List<string>() {"Title","Author","ISBN","MediaType"};
        do{
        Console.WriteLine("Enter 1 to go to books section and 2 to go to Media section");
        Choice = Console.ReadLine()!;
        } while(Choice != "1" && Choice != "2");

        if (Choice == "1"){
            Console.WriteLine("Search by what ?");
            string SearchType = Console.ReadLine()!;

            if (SearchList.Contains(SearchType)){
                
                switch(SearchType){
                    case "Title":
                    Console.WriteLine("Title: ");
                    string title = Console.ReadLine()!;
                    Book FoundBook = AAiTLibrary.SearchByBookTitle(title);
                    if (FoundBook.Title != ""){
                        AAiTLibrary.PrintBook(FoundBook);
                    }
                    else{
                        Console.WriteLine("Unable to find the book");
                    }
                    break;
                    case "Author":
                    Console.WriteLine("Author");
                    string SearchedAuthor = Console.ReadLine()!;
                    FoundBook = AAiTLibrary.SearchByBookTitle(SearchedAuthor);
                    if (FoundBook.Title != ""){
                        AAiTLibrary.PrintBook(FoundBook);
                    }
                    else{
                        Console.WriteLine("Unable to find the book");
                    }
                    break;
                    case "ISBN":
                    Console.WriteLine("ISBN");
                    string SearchedISBN = Console.ReadLine()!;
                    FoundBook = AAiTLibrary.SearchByAuthor(SearchedISBN);
                    if (FoundBook.Title != ""){
                        AAiTLibrary.PrintBook(FoundBook);
                    }
                    else{
                        Console.WriteLine("Unable to find the book");
                    }
                    break;
                }
            }



        }

        else{
            Console.WriteLine("Search by what ?");
            string SearchType = Console.ReadLine()!;
            switch(SearchType){
                    case "Title":
                    Console.WriteLine("Title");
                    string title = Console.ReadLine()!;
                    MediaItem item = AAiTLibrary.SearchByMediaTitle(title);
                    if (item.Title != ""){
                        AAiTLibrary.printMediaItem(item);
                    }
                    else{
                        Console.WriteLine("Unable to find the Media");
                    }
                    break;
                    case "MediaType":
                    Console.WriteLine("MediaType");
                    string mediaType = Console.ReadLine()!;
                    item = AAiTLibrary.SearchByMediaType(mediaType);
                    if (item.Title != ""){
                        AAiTLibrary.printMediaItem(item);
                    }
                    else{
                        Console.WriteLine("Unable to find the Media");
                    }
                    break;
        }

        



    }
}}