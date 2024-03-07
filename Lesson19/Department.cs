class Departament
{
    public int id;
    public string title;

    public Departament(int id, string title)
    {
        this.id = id;
        this.title = title;
    }

    public override string ToString()
    {
        return $"title: {this.title} id: {this.id}";
    }
}