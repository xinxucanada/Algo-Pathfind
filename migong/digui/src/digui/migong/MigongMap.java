package digui.migong;


import java.util.Random;

public class MigongMap {
    public Integer[][] map;
    public static Random rd = new Random();

    public static final int N = 5;
    public MigongMap(Integer n) {
        this.map = new Integer[2 * n + 1][2 * n + 1];
        SetWall();
    }

    public MigongMap(Integer m, Integer n) {
        this.map = new Integer[2 * m + 1][2 * n + 1];
        SetWall();
    }

    public void SetWall() {
        for (int i = 0; i < map.length; i++) {
            for (int j = 0; j < map[0].length; j++) {
                map[i][j] = 0;
            }
        }
        for (int i = 0; i < map[0].length; i++) {
            map[0][i] = 1;
            map[map.length - 1][i] = 1;
        }
        for (int i = 0; i < map.length; i++) {
            map[i][0] = 1;
            map[i][map[0].length - 1] = 1;
        }

        setWallDigui();

//        for (int i = 2; i < map[0].length - 2; i++) {
//            for (int j = 2; j < 9 ; j++) {
//                map[j][i] = 1;
//            }
//
//        }
//        for (int i = 1; i < map[0].length - 2; i++) {
//            map[9][i] = 1;
//        }
    }

    public void setWallDigui() {
        setWallDigui(1, 1, map.length - 2, map[0].length - 2, 0, 0, 0);
    }
//    public void setWallDigui(int x1, int y1, int x2, int y2){
//        if (x2 -x1 < 5 || y2 -y1 < 5) {
//            return;
//        }
//        int mX = rd.nextInt(x1 + 1, x2 - 1) ;
//        int mY = rd.nextInt(y1 + 1, y2 - 1) ;
//        for (int i = x1; i <= x2; i++) {
//            map[mY][i] = 1;
//        }
//        for (int i = x1; i <= x2; i++) {
//            map[mY][i] = 1;
//        }

//        for (int i = y1; i <= y2; i++) {
//            map[i][mX] = 1;
//        }
//        int xHole1 = rd.nextInt(x1, mX);
//        int xHole2 = rd.nextInt(mX + 1, x2);
//        int yhole = rd.nextBoolean()? rd.nextInt(y1,mY) : rd.nextInt(mY + 1, y2);
//        map[mY][xHole1] = 0;
//        map[mY][xHole2] = 0;
//        map[yhole][mX] = 0;
//
//        setWallDigui(x1, y1, mX, mY);
//        setWallDigui(x1, mY, mX,y2);
//        setWallDigui(mX, y1, x2, mY);
//        setWallDigui(mX, mY, x2, y2);
//    }
    public void setWallDigui(int x1, int y1, int x2, int y2, int xM1, int xM2, int yM) {
        if (x2 -x1 < N || y2 -y1 < N) {
            return;
        }
        int mX = 0;
        while (true) {
            // mX = rd.nextInt(x1 + 1, x2 - 1);
            mX = rd.nextInt( (x2 - 1) - (x1 + 1)) + x1 + 1;
            if (mX != xM1 && mX != xM2) {
                break;
            }
        }
        for (int i = y1; i <= y2 ; i++) {
            map[i][mX] = 1;
        }
        int mY = 0;
        while (true) {
            // mY = rd.nextInt(y1 + 1, y2 - 1);
            mY = rd.nextInt(y2 - 1 - (y1 + 1)) + y1 + 1;
            if (mY != yM) {
                break;
            }
        }
        for (int i = x1; i <= x2; i++) {
            map[mY][i] = 1;
        }
        // int xHole1 = rd.nextInt(x1, mX);
        int xHole1 = rd.nextInt(mX - x1) + x1;
        // int xHole2 = rd.nextInt(mX + 1, x2);
        int xHole2 = rd.nextInt(x2 - (mX + 1)) + mX + 1;
        // int yhole = rd.nextBoolean()? rd.nextInt(y1,mY) : rd.nextInt(mY + 1, y2);
        int yhole = rd.nextBoolean()? rd.nextInt(mY - y1) + y1 : rd.nextInt(y2 - (mY + 1)) + mY + 1;
        map[mY][xHole1] = 0;
        map[mY][xHole2] = 0;
        map[yhole][mX] = 0;

        setWallDigui(x1, y1, mX, mY, xHole1, xHole2, yhole);
        setWallDigui(x1, mY, mX,y2, xHole1, xHole2, yhole);
        setWallDigui(mX, y1, x2, mY, xHole1, xHole2, yhole);
        setWallDigui(mX, mY, x2, y2, xHole1, xHole2, yhole);

    }

    public void MapPrint() {
        for (int i = 0; i < map.length; i++) {
            for (int j = 0; j < map[0].length; j++) {
                System.out.print(map[i][j] + " ");
            }
            System.out.println();
        }
    }

    public boolean setWay(int x, int y) {
        if (map[map.length - 2][map[0].length - 2] == 2) {
            return true;
        }
        if (map[x][y] == 0) {
            map[x][y] = 2;
            if (setWay(x + 1, y)) return true;
            if (setWay(x, y + 1)) return true;
            if (setWay(x - 1, y)) return true;
            if (setWay(x, y  - 1)) return true;
            map[x][y] = 3;
            return false;
        }
        return false;
    }
}
