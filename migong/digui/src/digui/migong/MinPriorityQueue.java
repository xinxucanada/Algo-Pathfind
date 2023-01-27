package digui.migong;

public class MinPriorityQueue <T extends Comparable<T>> {
    //array pour tous les elements
    private T[] items;
    // quantite des elements
    private int n;

    // creer pq selon capacity
    public MinPriorityQueue(int capacity) {
        this.items = (T[]) new Comparable[capacity + 1];
        this.n = 0;
    }
    private boolean lessThan(int i, int j) {
        return items[i].compareTo(items[j]) <= 0;
    }

    private void exchange(int i, int j) {
        T temp = items[i];
        items[i] = items[j];
        items[j] = temp;
    }

    public T popMin() {
        T min = items[1];
        exchange(1, n);
        n--;
        sink(1);
        return min;
    }

    public void push(T t) {
        items[++n] = t;
        swim(n);
    }

    public int size() {
        return n;
    }

    public boolean isEmpty() {
        return n == 0;
    }

    private void swim(int i) {
        while (i > 1) {
            if (lessThan(i, i / 2)) {
                exchange(i, i / 2);
                i /= 2;
            } else {
                return;
            }
        }
    }

    private void sink(int i) {
        while (2 * i <= n) {
            int min;
            if (2 * i + 1 <= n) {
                if (lessThan(2 * i + 1, 2 * i )) {
                    min = 2 * i + 1;
                } else {
                    min = 2 * i;
                }
            } else {
                min = 2 * i;
            }

            if (lessThan(i, min)) {
                break;
            } else {
                exchange(i, min);
                i = min;
            }
        }
    }
}

