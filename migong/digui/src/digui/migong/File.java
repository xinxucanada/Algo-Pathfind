package digui.migong;

public class File <T>{
    private DoubleLiee<T> first;
    private DoubleLiee<T> last;

    public File() {
    }

    public DoubleLiee<T> getLast() {
        return last;
    }

    private void setLast(DoubleLiee<T> last) {
        this.last = last;
    }

    public DoubleLiee<T> getFirst() {
        return first;
    }

    private void setFirst(DoubleLiee<T> first) {
        this.first = first;
    }

    public T peak(){
        return this.first.getVal();
    }

    public void push(T v) {

        DoubleLiee<T> d = new DoubleLiee<>(v);

        if (this.first == null) {
            this.first = d;
            this.last = d;
        } else {
            this.last.setProchain(d);
            d.setDernier(this.last);
            this.last = d;
        }
    }

    public boolean isEmpty() {
        return this.first == null;
    }

    public T pop() {

        if (this.isEmpty()) {
            return null;
        } else {
            T val = this.first.getVal();
            this.first = this.first.getProchain();
            if (this.first!=null) {
                this.first.setDernier(null);
            } else {
                this.last = null;
            }
            return val;
        }
    }

    public void clear(){
        this.first = null;
        this.last = null;
    }

}
