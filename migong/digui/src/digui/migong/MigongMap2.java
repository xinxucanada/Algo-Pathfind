package digui.migong;

import java.awt.*;
import java.sql.Struct;
import java.util.Random;

public class MigongMap2 {

    public static final int N = 2147483647;
    public int minSteps = N;
    public int m;
    public int n;
    public int[][] map;
    public char[][] wallH;
    public char[][] wallV;
    public File<Point> file;
    public MinPriorityQueue<Point> tryPoints;
    public static Random rd = new Random();
    public static int times;
    public static final int[] dx = {1, 0, -1, 0};
    public static final int[] dy = {0, 1, 0, -1};
    public static final int[] dwx = {1, 0, 0, 0};
    public static final int[] dwy = {0, 1, 0, 0};
    public MigongMap2(int m, int n) {
        this.m = m;
        this.n = n;
        this.map = new int[m][n];
        this.wallH = new char[m + 1][n];
        this.wallV = new char[m][n + 1];
        setWallH();
        setWallV();
        file = new File<>();
    }

    public MigongMap2(int m) {
        this(m, m);
    }
    public void setWallH() {
        for (int i = 0; i < m + 1; i++) {
            for (int j = 0; j < n; j++) {
                if (i == 0 || i == m) {
                    wallH[i][j] = '-';
                } else {
                    wallH[i][j] = ' ';
                }
            }
        }
    }
    public void setWallV() {
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n + 1; j++) {
                if (j == 0 || j == n) {
                    wallV[i][j] = '|';
                } else {
                    wallV[i][j] = ' ';
                }
            }
        }
    }
    public void bfs() {
        bfs(0, 0);

    }
    public void bfs(int x, int y) {
        //定义右下上左格子和墙的位移变量

//        int[][] visited = new int[m][n];
        //创建队列保存需要对周边探索的点 *将file提到成员变量级别一遍其他函数调用, 寻找之前清空
        file.clear();
        // 将起点压入队列,并置为已访问
        Point start = new Point(x, y, 0, null);
        file.push(start);
        map[y][x] = 2;
        // 如果队列不为空则继续搜索
        while (!file.isEmpty()) {
            int currentX = file.peak().x;
            int currentY = file.peak().y;
            int currentStep = file.peak().step;
            //如果当前节点为出口,则返回,并打印步数
            if(currentX == n - 1 & currentY == m -1) {
                System.out.println(currentStep + " steps");
                drawPath(file.peak());
                return;
            }
            // 向四个方向试探 i = 0..3 代表右下左上
            for (int i = 0; i < 4; i++) {
//                如果左右方向就检测垂直墙
                if (i % 2 == 0) {
                    if (wallV[currentY + dwy[i]][currentX + dwx[i]] == ' ') { //墙为空则继续试探
                        int nextX = currentX + dx[i];
                        int nextY = currentY + dy[i];
                        if (map[nextY][nextX] == 0) { // 如果未被试探过
                            map[nextY][nextX] = 2;
                            file.push(new Point(nextX, nextY, currentStep + 1, file.peak()));
                        }
                    }
                } else {  //上下方法,检测水平墙
                    if (wallH[currentY + dwy[i]][currentX + dwx[i]] == ' ') { //墙为空则继续试探
                        int nextX = currentX + dx[i];
                        int nextY = currentY + dy[i];
                        if (map[nextY][nextX] == 0) { // 如果未被试探过
                            map[nextY][nextX] = 2;
                            file.push(new Point(nextX, nextY, currentStep + 1, file.peak()));
                        }
                    }
                }
            }
            file.pop();
        }
        //如果队列为空还没有到出口,则显示未找到
        System.out.println("Pas de chance");
    }
    public void drawPath(Point point) {
        if (point == null) return;
        map[point.y][point.x] = 3;
        drawPath(point.pre);
    }
    public void dfs() {
        dfs(new Point(0, 0, 0, null));
        drawPath(file.peak());
    }
    public void dfs(Point point) {
        if (point.x == m -1 && point.y == n - 1) {
            if (point.step < minSteps) {
                minSteps = point.step;
                file.clear();
                file.push(point.copy());
                while (point.pre != null) {
                    point = point.pre;
                    file.push(point);
                }
                System.out.println(minSteps + " steps");
                return;
            }
        }
        for (int i = 0; i < 4; i++) {
//                如果左右方向就检测垂直墙
            if (i % 2 == 0) {
                if (wallV[point.y + dwy[i]][point.x + dwx[i]] == ' ') { //墙为空则继续试探
                    int nextX = point.x + dx[i];
                    int nextY = point.y + dy[i];
                    if (map[nextY][nextX] != 2) { // 如果未被试探过
                        map[nextY][nextX] = 2;
                        dfs(new Point(nextX, nextY,point.step + 1, point));
                        map[nextY][nextX] = 1;
                    }
                }
            } else {  //上下方法,检测水平墙
                if (wallH[point.y + dwy[i]][point.x + dwx[i]] == ' ') { //墙为空则继续试探
                    int nextX = point.x + dx[i];
                    int nextY = point.y + dy[i];
                    if (map[nextY][nextX] != 2) { // 如果未被试探过
                        map[nextY][nextX] = 2;
                        dfs(new Point(nextX, nextY,point.step + 1, point));
                        map[nextY][nextX] = 1;
                    }
                }
            }
        }
        return;
    }

    public void aStar() {
        aStar(0, 0);
        drawPath(file.peak());
    }

    public void Reset() {
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                map[i][j] = 0;
            }
        }
    }
    public void aStar(int x, int y) {
        Point point = new Point(x, y, 0, null, (n - 1 - x) + (m - 1 - y));
        tryPoints = new MinPriorityQueue<>(2 * (m + n));
        tryPoints.push(point);
        //A* 算法中我们设定为探索墙为0, 已探索为2, 尝试点为1, 最终路径为3
        while (!tryPoints.isEmpty()) {
            point = tryPoints.popMin();
            if (point.x == m -1 && point.y == n - 1){  //如果弹出点就是终点, 回溯路径,将路径存入队列file,以便后期绘图,并返回
                System.out.println(point.step + " steps");
                file.clear();
                file.push(point.copy());
                while (point.pre != null) {
                    point = point.pre;
                    file.push(point);
                }

                return;
            }
            map[point.y][point.x] = 2; //否则, 将弹出点设为已探索
            for (int i = 0; i < 4; i++) {
//                如果左右方向就检测垂直墙
                if (i % 2 == 0) {
                    if (wallV[point.y + dwy[i]][point.x + dwx[i]] == ' ') { //墙为空则继续试探
                        int nextX = point.x + dx[i];
                        int nextY = point.y + dy[i];
                        if (map[nextY][nextX] == 0) { // 如果未被试探过
                            map[nextY][nextX] = 1; // 如此点未被探索,则暂时设为尝试点,并压入优先队列
                            tryPoints.push(new Point(nextX, nextY, point.step + 1, point,(n - 1 - nextX) + (m - 1 - nextY) ));
                        }
                    }
                } else {  //上下方法,检测水平墙
                    if (wallH[point.y + dwy[i]][point.x + dwx[i]] == ' ') { //墙为空则继续试探
                        int nextX = point.x + dx[i];
                        int nextY = point.y + dy[i];
                        if (map[nextY][nextX] == 0) { // 如果未被试探过
                            map[nextY][nextX] = 1;
                            tryPoints.push(new Point(nextX, nextY, point.step + 1, point,(n - 1 - nextX) + (m - 1 - nextY) ));
                        }
                    }
                }
            }
        }
    }

    public void block() {
        for (int i = 0; i < 9; i++) {
            wallH[2][i] = '-';
        }
        for (int i = 2; i < 10; i++) {
            wallH[5][i] = '-';
        }
    }
    public void blockDigui() {
        blockDigui(0, 0, n - 1, m - 1);
    }
    public void blockDigui(int x1, int y1, int x2, int y2) {
        //分格过小则退出
        if (x2 - x1 < 2 || y2 - y1 < 2) {
            return;
        }
        //随机取横竖分割线
        int xM = rd.nextInt( x2 + 1 - (x1 + 2)) + x1 + 2;
        // int xM = rd.nextInt(x1 + 2, x2 + 1);
        int yM = rd.nextInt(y2 + 1 - (y1 + 2)) + y1 + 2;
        // int yM = rd.nextInt(y1 + 2, y2 + 1);
        //分格地图
        //横分割线
        for (int i = x1; i < x2 + 1; i++) {
            wallH[yM][i] = '-';
        }
        // 竖分割线
        for (int i = y1; i < y2 + 1; i++) {
            wallV[i][xM] = '|';
        }
        // 在分隔线上挖3个洞
        int xHole1 = rd.nextInt(xM - x1) + x1;
        // int xHole1 = rd.nextInt(x1, xM);
        int xHole2 = rd.nextInt(x2 + 1 - xM) + xM;
        // int xHole2 = rd.nextInt(xM, x2 + 1);
        int yHole = rd.nextInt( yM - y1) +y1;
        // int yHole = rd.nextInt(y1, yM);
        wallH[yM][xHole1] = ' ';
        wallH[yM][xHole2] = ' ';
        wallV[yHole][xM] = ' ';
        // 递归调用在分区块内制造路障
        blockDigui(x1, y1, xM - 1, yM -1);
        blockDigui(xM, y1, x2, yM -1);
        blockDigui(x1, yM, xM - 1, y2);
        blockDigui(xM, yM, x2, y2);

    }
    public void printMap() {
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                System.out.print('+');
                System.out.print(wallH[i][j]);
            }
            System.out.println('+');
            for (int j = 0; j < n; j++) {
                System.out.print(wallV[i][j]);
                System.out.print(map[i][j]);
            }
            System.out.println(wallV[i][n]);
        }
        for (int i = 0; i < n; i++) {
            System.out.print('+');
            System.out.print(wallH[m][i]);
        }
        System.out.println('+');
    }
    public boolean setWay() {
        return setWay(0, 0);
    }
    public boolean setWay(int x, int y) {
        if (map[m - 1][n - 1] == 2) {
            return true;
        }
        if (map[y][x] == 0) {
            map[y][x] = 2;
            if (wallH[y + 1][x] != '-') {
                if (setWay(x, y + 1)) return true;
            }
            if (wallV[y][x + 1] != '|') {
                if (setWay(x + 1, y)) return true;
            }
            if (wallH[y][x] != '-') {
                if (setWay(x, y - 1)) return true;
            }
            if (wallV[y][x] != '|') {
                if (setWay(x - 1, y)) return true;
            }
            map[y][x] = 3;
            return false;
        } else {
            return false;
        }
    }
    class Point implements Comparable<Point>{
        public int x;
        public int y;
        public int step;
        public Point pre;


        public int distanceTobe;

        public int totalDistance;

        public Point(int x, int y, int step, Point pre, int distanceTobe) {
            this.x = x;
            this.y = y;
            this.step = step;
            this.pre = pre;
            this.distanceTobe = distanceTobe;
            this.totalDistance = step + distanceTobe;
        }

        public Point(int x, int y, int step, Point pre) {
            this.x = x;
            this.y = y;
            this.step = step;
            this.pre = pre;
        }
        public Point copy(){
            return new Point(this.x, this.y, this.step, this.pre);
        }

        @Override
        public String toString() {
            return "Point{" +
                    "x=" + x +
                    ", y=" + y +
                    ", step=" + step +
                    '}';
        }

        @Override
        public int compareTo(Point o) {
            if (this.totalDistance == o.totalDistance) return this.step - o.step;
            return this.totalDistance - o.totalDistance;
        }
    }
}
