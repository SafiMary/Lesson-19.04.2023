using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lesson_19._04._2023
{


    namespace TarifCounterDemo
    {
        enum Month
        {
            Январь = 1,
            Февраль,
            Март,
            Апрель,
            Май,
            Июнь,
            Июль,
            Август,
            Сентябрь,
            Октябрь,
            Ноябрь,
            Декабрь
        }
        class myMeterReader
        {
            int waterCount;
            public int WaterCount
            {
                get
                {
                    return waterCount;
                }
                set
                {
                    waterCount = value;
                }
            }
            public myMeterReader(int _number)
            {
                waterCount = _number;
            }
            public string convert2Str()
            {
                string _tmp = waterCount.ToString();
                while (_tmp.Length < 8)
                {
                    _tmp = "0" + _tmp;
                }
                return _tmp;
            }
        }
        struct myMeterReader02
        {
            myMeterReader Cold;
            myMeterReader Hot;
        }
        class myCounter
        {
            int _min = 0, _max = 99999999;
            List<myMeterReader> myBillList = new List<myMeterReader>();
            public myCounter(int _number)
            {
                if (_number >= _min || _number <= _max)
                {
                    myMeterReader myMR = new myMeterReader(_number);
                    myBillList.Add(myMR);
                }
            }
            public bool addMetric(int _number)
            {
                bool result = false;
                int _lastElement = myBillList.Count;
                if (myBillList[_lastElement - 1].WaterCount <= _number)
                {
                    myMeterReader myMR = new myMeterReader(_number);
                    myBillList.Add(myMR);
                    result = true;
                }
                return result;
            }
            public List<myMeterReader> getValues()
            {
                return myBillList;
            }
        }
        internal class Program
    {

        static void Main(string[] args)
        {
            int[] counter = new int[] { 12, 3, 5, 14, 140 };
            var _meterReader = new myCounter(0);
            foreach (var item in counter)
            {
                Console.WriteLine($"Пытаюсь добавить значение {item}");
                if (_meterReader.addMetric(item))
                {
                    Console.WriteLine($"Добавлено значение {item}");
                }
                else
                {
                    Console.WriteLine($"Значение {item} не добавлено");
                }
            }
            Console.WriteLine("\n\nИтог:");
            int _month = 1;
            string myMonth;
            foreach (var item in _meterReader.getValues())
            {
                myMonth = Enum.GetName(typeof(Month), _month);
                Console.WriteLine($"За {myMonth} \t= {item.convert2Str()}");
                _month++;
            }

        }
    }
}
}
