package digui.migong;


public class MigongTest {
    public static void main(String[] args) {

//        MigongMap migong = new MigongMap(10);
//        migong.MapPrint();
//        MigongMap map2 = new MigongMap(5, 6);
//        map2.MapPrint();

//        migong.setWay(1,1);
//        migong.MapPrint();
        MigongMap2 migong2 = new MigongMap2(12);
        migong2.printMap();
        System.out.println("=====================================================================");
        migong2.blockDigui();
        migong2.printMap();
        System.out.println("=====================================================================");
        migong2.aStar();
//        migong2.dfs();
        migong2.printMap();
        System.out.println("=====================================================================");
        migong2.Reset();
        migong2.dfs();
        migong2.printMap();
        System.out.println("=====================================================================");
        migong2.Reset();
        migong2.bfs();
        migong2.printMap();
    }
}
