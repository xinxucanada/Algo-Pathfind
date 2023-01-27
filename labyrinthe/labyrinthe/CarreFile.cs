using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinthe
{
	internal class CarreFile<T>
	{
		private NodeDoubleLiee<T> first;
		private NodeDoubleLiee<T> last;

		public CarreFile()
		{
		}

		public NodeDoubleLiee<T> getLast()
		{
			return last;
		}

		private void setLast(NodeDoubleLiee<T> last)
		{
			this.last = last;
		}

		public NodeDoubleLiee<T> getFirst()
		{
			return first;
		}

		private void setFirst(NodeDoubleLiee<T> first)
		{
			this.first = first;
		}

		public T peak()
		{
			return this.first.getVal();
		}

		public void push(T v)
		{

			NodeDoubleLiee<T> d = new NodeDoubleLiee<T>(v);
			//Console.WriteLine("push " + v.ToString());

			if (this.first == null)
			{
				this.first = d;
				this.last = d;
			}
			else
			{
				this.last.setProchain(d);
				d.setDernier(this.last);
				this.last = d;
			}
		}

		public Boolean isEmpty()
		{
			return this.first == null;
		}

		public T pop()
		{

			if (this.isEmpty())
			{
				return default(T);
			}
			else
			{
				T val = this.first.getVal();
				this.first = this.first.getProchain();
				if (this.first != null)
				{
					this.first.setDernier(null);
				}
				else
				{
					this.last = null;
				}
				return val;
			}
		}

		public void clear()
		{
			this.first = null;
			this.last = null;
		}
	}
}
