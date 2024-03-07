Departament dep1 = new Departament(0, "Информационные технологии");
Departament dep2 = new Departament(1, "Отдел кадров");
Departament dep3 = new Departament(2, "Бухгалтерия");
Cosole.WriteLine(dep1);
Cosole.WriteLine(dep2);
Cosole.WriteLine(dep3);

Worker worker1 = new Worker(0, 2, 23, "Мария Ивановна", 1234);
Worker worker2 = new Worker(1, 0, 26, "Мария Степановна", 3456);
Worker worker3 = new Worker(2, 2, 33, "Василий Петрович", 5432);
Worker worker4 = new Worker(3, 0, 33, "Игнат Петрович", 5432);

Cosole.WriteLine(worker1);
Cosole.WriteLine(worker2);
Cosole.WriteLine(worker3);
Cosole.WriteLine(worker4);

DataBase db = new();

db.append_dep(dep1);
db.append_dep(dep2);
db.append_dep(dep3);

db.append_worker(worker1);
db.append_worker(worker2);
db.append_worker(worker3);
db.append_worker(worker4);

Console.WriteLine(db.select_all_dep());
Console.WriteLine();
Console.WriteLine(db.select_all_worker());