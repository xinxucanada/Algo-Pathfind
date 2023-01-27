using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinthe
{
	internal class NodeDoubleLiee<T>
	{
		private T val;
		private NodeDoubleLiee<T> dernier;
		private NodeDoubleLiee<T> prochain;
		public NodeDoubleLiee()
		{
		}
		public NodeDoubleLiee(T val)
		{
			this.val = val;
		}
		public NodeDoubleLiee(T val, NodeDoubleLiee<T> dernier, NodeDoubleLiee<T> prochain)
		{
			this.val = val;
			this.dernier = dernier;
			this.prochain = prochain;
			this.dernier.setProchain(this);
			this.prochain.setDernier(this);
		}
		public T getVal()
		{
			return val;
		}
		public void setVal(T val)
		{
			this.val = val;
		}
		public NodeDoubleLiee<T> getDernier()
		{
			return dernier;
		}
		public void setDernier(NodeDoubleLiee<T> dernier)
		{
			this.dernier = dernier;
		}
		public NodeDoubleLiee<T> getProchain()
		{
			return prochain;
		}
		public void setProchain(NodeDoubleLiee<T> prochain)
		{
			this.prochain = prochain;
		}

	}
}
