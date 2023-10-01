using Lab_06;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_05
{
    abstract class Gift
    {
        public abstract void Add(Component obj);
        public abstract void Remove(Component obj);
        public abstract void WriteGift();
    }

    class ContainerGift : Gift
    {
        public Component[] AllComponent = new Component[0];
        private int MaxItem = 10;
        public int ItemsCount
        {
            get
            {
                return AllComponent.Length;
            }
        }

    public override void Add(Component obj)
        {
            Array.Resize(ref AllComponent, ItemsCount + 1);
            AllComponent[ItemsCount - 1] = obj;
            if(ItemsCount == MaxItem)
            {
                throw new MaxCollection("Превышен размер коллекции");
            }
        }

        public override void Remove(Component obj)
        {

            bool checkingAvailability = false;

            if (ItemsCount != 0)
            {
                for(int i = 0; i < ItemsCount; i++)
                {
                    if (AllComponent[i] == obj)
                    {
                        for (int j = i; j < ItemsCount - 1; j++)
                        {
                            AllComponent[j] = AllComponent[j + 1];
                        }
                        Array.Resize(ref AllComponent, ItemsCount - 1);
                        checkingAvailability = true;
                    }
                }
            }

            if (!checkingAvailability) throw new DeleteNullObject("Вы пытаетесь удалить элемент которого не существует");
        }

        public override void WriteGift()
        {
            if(AllComponent.Length == 0)
            {
                throw new NullReferenceException("Коллекция пустая, вы не можете вызвать данный метод");
            }
            for (int i = 0; i < ItemsCount; i++)
            {
                Console.WriteLine($"{i} компонент: {AllComponent[i].ToString()}");
            }
        }

        private class GiftEnumerator : IEnumerator
        {
            private readonly Component[] _data;
            private int _position = -1;

            public GiftEnumerator(Component[] data)
            {
                _data = new Component[data.Length];
                Array.Copy(data, _data, data.Length);
            }

            public object Current
            {
                get { return _data[_position]; }
            }

            public bool MoveNext()
            {
                if (_position < _data.Length - 1)
                {
                    _position++;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                _position = -1;
            }


        }

        public IEnumerator GetEnumerator() { return new GiftEnumerator(AllComponent); }

        public class SumComponent : IComparer<Component>
        {
            public int Compare(Component x, Component y)
            {
                if (x.VolumeComponent > y.VolumeComponent)
                    return 1;
                else if (x.VolumeComponent < y.VolumeComponent)
                    return -1;
                else return 0;
            }
        }
    }

    class Component
    {
        public double VolumeComponent {get;set;}
        public double MassaComponent { get; set; }
        public int PriceComponent { get; set; }
        public string NameComponent { get; set; }

        public Component(double volumeComponent, double massaComponent, int priceComponent, string nameComponent)
        {
            VolumeComponent = volumeComponent;
            MassaComponent = massaComponent;
            PriceComponent = priceComponent;
            NameComponent = nameComponent;
        }

        public override string ToString()
        {
            return $"Название = {NameComponent};Масса = {MassaComponent}; Объём = {VolumeComponent}; Цена = {PriceComponent}";
        }
    }
}
