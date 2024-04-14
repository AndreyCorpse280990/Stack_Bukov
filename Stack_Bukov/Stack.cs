namespace Stack_Bukov;

public class Stack
{

    protected object[] Data { get; set; }
    protected int Capacity { get; set; }
    protected const int MIN_ALLOWED_STACK_SIZE = 10;


// Конструктор по умолчанию, создает стек с емкостью по умолчанию равной 10
    public Stack()
    {
        Data = new object[MIN_ALLOWED_STACK_SIZE];
        Capacity = 0;
    }

    // Конструктор для создания стека с заданной емкостью
    public Stack(int n)
    {
        int size = Math.Max(n, MIN_ALLOWED_STACK_SIZE);
        Data = new object[size];
        Capacity = 0;
    }

    // Push – метод добавления элемента в стек
    public bool Push(object value)
    {
        if (Capacity == Data.Length )
        {
            return false;
        }
        Data[Capacity++] = value;// добавление элемента в стек
        return true;    
    }

    // Pop – метод извлечения элемента из стека, возвращает элемент с верхушки стека,
    // при это удаляя его из стека
    public object Pop(out bool ok)
    {
        if (Capacity == 0)
        {
            ok = false; // стек пустой
            return null;
        }
        ok = true; // стек не пустой
        return Data[--Capacity]; // извлечение элемента из стека и уменьшение ёмкости
    }
    
    // Top - аналогично Pop но только без удаления элемента из стека
    public object Top(out bool ok)
    {
        if (Capacity == 0)
        {
            ok = false; 
            return null;
        }
        ok = true;
        return Data[Capacity - 1];
    }
    
    // ToString() string – перегруженный метод получения стека в виде строки, выводить заполненную часть стека,
    // его размер и максимально допустимый размер
    public string ToString()
    {
        return $"Stack: [{string.Join(", ", Data.Take(Capacity))}] | Current size: {Capacity} | Max size: {Data.Length}";
    }
}