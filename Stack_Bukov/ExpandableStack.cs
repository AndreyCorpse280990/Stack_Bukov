    namespace Stack_Bukov;

    public class ExpandableStack : Stack
    {
        private object[] _data; // Приватное поле для хранения данных стека
        private static readonly double DEFAULT_GROW_COEFFICIENT = 2.0; // Коэффициент увеличения размера стека по умолчанию
        private readonly double _growCoefficient; // Текущий коэффициент увеличения размера стека

        // Конструктор, создающий стек заданного размера
        public ExpandableStack(int n) : base(n)
        {
            int size = Math.Max(n, MIN_ALLOWED_STACK_SIZE);
            _data = new object[size];
            _growCoefficient = DEFAULT_GROW_COEFFICIENT;
        }
        
        // Конструктор, создающий стек заданного размера с указанным коэффициентом
        public ExpandableStack(int n, double growCoefficient) : base(n)
        {
            _data = new object[n];
            _growCoefficient = growCoefficient > 1.0 ? growCoefficient : DEFAULT_GROW_COEFFICIENT;
        }

        public ExpandableStack() : base()
        {
            _data = new object[MIN_ALLOWED_STACK_SIZE]; // Инициализация массива данных с минимальным размером
            _growCoefficient = DEFAULT_GROW_COEFFICIENT; // Установка коэффициента увеличения размера по умолчанию
        }

        // Переопределение метода Push для изменения размера стека при заполнении
        public  bool Push(object value)
        {
            if (Capacity == _data.Length)
            {
                // Изменение размера стека
                int newCapacity = (int)(_data.Length * _growCoefficient);
                Array.Resize(ref _data, newCapacity);
            }

            _data[Capacity++] = value;// Добавление элемента в стек
            return true;
        }

        // Переопределение свойства Data для использования приватного поля данных
        protected object[] Data
        {
            get { return _data; }
            set { _data = value; }
        }
        
        // Shrink – метод ужатия емкости стека.
        // Делает емкость стека равной текущем размеру стека (capcity == size)
        public void Shrink()
        {
            if (Capacity < Data.Length)
            {
                Array.Resize(ref _data, Capacity);
            }
        }
        
        // Переопределение метода ToString
        public new string ToString()
        {
            return $"Stack: [{string.Join(", ", _data.Take(Capacity))}] " +
                   $"| Current size: {Capacity} " +
                   $"| Max size: {_data.Length}";
        }
    }