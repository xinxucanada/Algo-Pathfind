using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace labyrinthe
{
	//internal class MinPriorityQueue
	public class MinPriorityQueue {
    //array pour tous les elements
    private Carre[] items;
	// quantite des elements
	private int n;

	// creer pq selon capacity
	public MinPriorityQueue(int capacity)
	{
		this.items = new Carre[capacity + 1];
		this.n = 0;
	}
	private bool lessThan(int i, int j)
	{
		if (items[i].totalDistance < items[j].totalDistance) return true;
		if (items[i].totalDistance == items[j].totalDistance && items[i].step < items[j].step) return true;
		return false;
	}

	private void exchange(int i, int j)
	{
		Carre temp = items[i];
		items[i] = items[j];
		items[j] = temp;
	}

	public Carre PopMin()
	{
		Carre min = items[1];
		exchange(1, n);
		n--;
		sink(1);
		return min;
	}

	public void Push(Carre t)
	{
		items[++n] = t;
		swim(n);
	}

	public int size()
	{
		return n;
	}

	public bool isEmpty()
	{
		return n == 0;
	}

	private void swim(int i)
	{
		while (i > 1)
		{
			if (lessThan(i, i / 2))
			{
				exchange(i, i / 2);
				i /= 2;
			}
			else
			{
				return;
			}
		}
	}

	private void sink(int i)
	{
		while (2 * i <= n)
		{
			int min;
			if (2 * i + 1 <= n)
			{
				if (lessThan(2 * i + 1, 2 * i))
				{
					min = 2 * i + 1;
				}
				else
				{
					min = 2 * i;
				}
			}
			else
			{
				min = 2 * i;
			}

			if (lessThan(i, min))
			{
				break;
			}
			else
			{
				exchange(i, min);
				i = min;
			}
		}
	}
}
}
