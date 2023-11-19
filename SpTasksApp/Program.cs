/*
Console.WriteLine($"{Task.CurrentId} Start");

Task task1 = new Task(Hello);
Task task2 = Task.Factory.StartNew(Hello);
Task task3 = Task.Run(Hello);
task1.RunSynchronously();

task3.Wait();
task2.Wait();
task1.Wait();

Console.WriteLine($"{Task.CurrentId} End");

void Hello()
{
    Console.WriteLine($"{Task.CurrentId} Start");
    Console.WriteLine("Hello World");
    Console.WriteLine($"{Task.CurrentId} End");
}
*/

/*
Console.WriteLine($"Main Start");

var outer = Task.Factory.StartNew(() =>
{
    Console.WriteLine($"Outer Task Start");
    var inner = Task.Factory.StartNew(() =>
    {
        Console.WriteLine($"Inner Task Start");
        Thread.Sleep(1000);
        Console.WriteLine($"Inner Task Finish");
    }, TaskCreationOptions.AttachedToParent);
    Console.WriteLine($"Outer Task Finish");
});

outer.Wait();

Console.WriteLine($"Main Finish");
*/

/*
Task[] tasks = new Task[5];

tasks[0] = new Task(() => { Thread.Sleep(100); Console.WriteLine($"Task #1");  });
tasks[1] = new Task(() => { Thread.Sleep(300); Console.WriteLine($"Task #2");  });
tasks[2] = new Task(() => { Thread.Sleep(100); Console.WriteLine($"Task #3");  });
tasks[3] = new Task(() => { Thread.Sleep(500); Console.WriteLine($"Task #4");  });
tasks[4] = new Task(() => { Thread.Sleep(300); Console.WriteLine($"Task #5");  });



foreach (var task in tasks)
    task.Start();

int index = Task.WaitAny(tasks);
Console.WriteLine(index);
//foreach(var task in tasks)
//    Console.WriteLine(task.Status);
*/


/*
Task<int> accTask = new Task<int>(Accum);
accTask.Start();

int summa = accTask.Result;
Console.WriteLine(summa);

int Accum()
{
    int result = 0;
    for (int i = 1; i <= 100; i++)
        result += i;
    return result;
}
*/

/*
Task task1 = new(() => 
{
    Console.WriteLine($"Task 1 - {Task.CurrentId}");
});


Task task2 = task1.ContinueWith((task) =>
{
    Console.WriteLine($"Task Prev - {task.Id}");
    Console.WriteLine($"Task 2 - {Task.CurrentId}");
});

task1.Start();

task2.Wait();
*/

/*
Task<int> task1 = new(() =>
    {
        int res = 0;
        for (int i = 1; i <= 100; i++)
            res += i;
        return res;
    });

Task task2 = task1.ContinueWith((task) =>
{
    Console.WriteLine($"Summa = {task.Result}");
});

task1.Start();
task2.Wait();
*/

//Parallel.Invoke(PrintIndex, SleepMethod, PrintMethod);
Parallel.For(20, 25, Counter);

List<string> names = new List<string>()
{
    "Bob", "Joe", "Tom", "Sam", "Tim", "Leo"
};

Parallel.ForEach<string>(names, HelloName);



void PrintIndex()
{
    for(int i = 0; i < 50; i++)
    {
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} {i}");
        Thread.Sleep(20);
    }
        
}

void SleepMethod()
{
    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Start Sleep");
    Thread.Sleep(1000);
    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Finish Sleep");
}

void PrintMethod()
{
    for (int i = 0; i < 50; i++)
    {
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} {i}");
        Thread.Sleep(10);
    }

}

void Counter(int n)
{
    for (int i = 0; i < n; i++)
    {
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} {i}");
        Thread.Sleep(10);
    }
}

void HelloName(string name, ParallelLoopState state)
{
    if (name == "Tom")
        state.Break();
    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - Hello {name}");
}
