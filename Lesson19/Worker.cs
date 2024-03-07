class Worker
{
    public int id;
    public int depId;
    public int age;
    public string fullName;
    public int salary;

    public Worker(int id, int depId, int age, string fullName, int salary)
    {
        this.id = id;
        this.depId = depId;
        this.age = age;
        this.fullName = fullName;
        this.salary = salary;
    }

    public override string ToString()
    {
        return $"id: {this.id} Full name: {this.fullName} age: {this.age} salary: {this.salary} dep id: {this.depId}";
    }
}
