using System;
using System.Collections;

namespace AthensDefender.Util
{
	/// <summary>
	/// A Recyling Array - sort of like a queue, but should be better performance
	/// </summary>
	public class RecylingArray : IEnumerable, IEnumerator
	{
		private object[] _items;
		private int _openIndex = 0;
		private int _arrayCapacity;
		private int _currentIteratorPosition = -1;

		public RecylingArray(int arrayCapacity)
		{
			this._arrayCapacity = arrayCapacity;
			_items = new object[ _arrayCapacity ];
		}

		public void Add(object item)
		{
			_items[ _openIndex++ ] = item;
			if(_openIndex == _arrayCapacity)
			{
				_openIndex = 0;
			}
		}

		#region IEnumerable Members

		public IEnumerator GetEnumerator()
		{
			return (IEnumerator)this; 
		}

		#endregion

		#region IEnumerator Members

		public void Reset()
		{
			_currentIteratorPosition = -1;	
		}

		public object Current
		{
			get { return _items [_currentIteratorPosition ];	}
		}

		public bool MoveNext()
		{
			_currentIteratorPosition++;
			if(_currentIteratorPosition < _arrayCapacity && _items[ _currentIteratorPosition ] != null)
			{
				return true;
			}
			else
			{
				Reset();
				return false;
			}
		}
		#endregion
	}
}
