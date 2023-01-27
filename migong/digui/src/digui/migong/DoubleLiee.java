package digui.migong;

public class DoubleLiee<T>{
    private T val;
    private DoubleLiee<T> dernier;
    private DoubleLiee<T> prochain;
    public DoubleLiee() {
    }
    public DoubleLiee(T val) {
        this.val = val;
    }
    public DoubleLiee(T val, DoubleLiee<T> dernier, DoubleLiee<T> prochain) {
        this.val = val;
        this.dernier = dernier;
        this.prochain = prochain;
        this.dernier.setProchain(this);
        this.prochain.setDernier(this);
    }
    public T getVal() {
        return val;
    }
    public void setVal(T val) {
        this.val = val;
    }
    public DoubleLiee<T> getDernier() {
        return dernier;
    }
    public void setDernier(DoubleLiee<T> dernier) {
        this.dernier = dernier;
    }
    public DoubleLiee<T> getProchain() {
        return prochain;
    }
    public void setProchain(DoubleLiee<T> prochain) {
        this.prochain = prochain;
    }
    @Override
    public String toString() {
        String up = this.dernier != null? "=>" : "|->" ;
        String down = this.prochain != null? "<=" : "<-|" ;
        return up + val + down;
    }
}