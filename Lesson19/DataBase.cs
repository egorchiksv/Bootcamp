class DataBase
{
    List<Departament> dep_table;
    List<Worker> worker_table;

    public DataBase()
    {
        dep_table = new();
        worker_table = new List<Worker>();
    }

    public void append_worker(Worker worker)
    {
        worker_table.Add(worker);
    }

     public void append_dep(Departament departament)
    {
        dep_table.Add(departament);
    }

    public string select_all_dep()
    {
        string output = String.Empty;

        foreach (var item in dep_table)
        {
            output += $"{item.title}\n"
        }

        return output;
    }

    public string select_all_worker()
    {
        string output = String.Empty;

        foreach (var item in worker_table)
        {
            output += $"{item.fullName} {item.age}\n"
        }

        return output;
    }


    public List<(string, int, string)> report()
    {
        List<(string, int, string)>rep = new();
        rep.Add(("Маша", 23, "ИТ"));
        return rep;
    }
}