# labo3Algo
2194517 2295847
# Nom
Générateur de labyrinthes
# Installation
partie C#: Visual Studio 2019 ou 2022 (algorithme complèt, interface graphic, démonstration animée)
partie JAVA: VS code + java extension ou IntelliJ IDEA(programme incomplet utilisé pour étudier/tester les algorithmes)
# Description
## partie 1
1. Utiliser algorithem 'division' pour assurer les labyrinthes ont au moins une solution
2. Les labyrinthes sont générés de manière aléatoire. (Divisions horizontales et verticales se font aléatoirment.
3. L'entrée en haut à gauche, sortie en bas à droite.
## partie 2
1. Profondeur:
1.1 chercher chemin plus profondeur plus possible, change état comme visité(couleur verte). une fois tout bloqué, change état comme mort(couleur noire), return à noeud parent. Programme s'arrête dès qu'on trouve la première solution.
![image](https://user-images.githubusercontent.com/111302670/216750078-a53bd11d-9b8d-48d1-a1a8-fb6ff3536acb.png)
![image](https://user-images.githubusercontent.com/111302670/216750402-64271e6a-148c-4c48-a372-acefaf2a697d.png)

1.2 Même chose 1.1, sauf que programme ne s'arrête pas lorsqu'on trouve une solution, on recule, on cherche toutes les solutions. Puis trouve la meilleure.
chemin visité au courrent(couleur verte); carrées déjà visitées (couleur bleue)
![image](https://user-images.githubusercontent.com/111302670/216750435-bf43ffe8-bd67-4311-8d35-48fe495cf111.png)
![image](https://user-images.githubusercontent.com/111302670/216750447-0487d278-e0a3-48f2-b6c7-b7badf048aae.png)

2. Largeur:
On met les carrées qui ont la même distance de l'entrée dans la file(couleur bleue), puis pop une de la file(FIFO couleur verte), chercher ses voisins, push les voisins possibles dans la file(couleur bleue).
![image](https://user-images.githubusercontent.com/111302670/216752658-712a645c-5cd6-4eee-b524-89c98330e915.png)
![image](https://user-images.githubusercontent.com/111302670/216750528-60a57d12-5030-489f-b6e2-8138ac6fd68c.png)

3. A*:
On push les carrées dans priority queue (état "essaye" couleur bleue), ensuite pop celle qui a la plus courte distance total(f = coût acctual + heuristique). changer son état comme "visited"(couleur verte), à la fois, push ses voisins possibles dans priority queue.(ici, pas besoin de comparer qui est le meilleur voisin, push tous dans la priority queue qui va s'occuper de ça)
![image](https://user-images.githubusercontent.com/111302670/216750690-aab38c00-cabc-4daa-94ec-91dbe80129ba.png)
![image](https://user-images.githubusercontent.com/111302670/216750699-4edc564f-e8bb-4e7d-9260-4aca99aa8740.png)

structure de la priority queue(https://www.bilibili.com/video/BV1iJ411E7xW?p=109&vd_source=63d29f729d495ccb836eeccb160a82dd)
![image](https://user-images.githubusercontent.com/111302670/216779666-02138e20-7cb4-4b87-942d-5daabc7e4766.png)

## partie 3
Implémenter un menu permettant d'effectuer les étapes suivantes:

1. Générer un nouveau labyrinthe.

 ![image](https://user-images.githubusercontent.com/111302670/216751075-01b4dcd0-70d9-4f18-b37b-ec69838aec93.png)

2. Afficher la liste de labyrinthes.

![image](https://user-images.githubusercontent.com/111302670/216751086-17705363-bc31-4dc3-b7f2-0f7da36f5ad1.png)

3. Choisir un labyrinthe existant (triés en ordre de difficultés).
### Le tri des labyrinthes se fait en  O(n*log(n)) (on utilise tri fusion)
 ![image](https://user-images.githubusercontent.com/111302670/216751137-707875e1-e228-49df-9e76-d4afdbac0a52.png)

4. Afficher le labyrinthe choisi.
![image](https://user-images.githubusercontent.com/111302670/216751168-ca81783f-d22d-4aba-b626-11908fb61c95.png)

5. Choisir l'algorithme de résolution.
![image](https://user-images.githubusercontent.com/111302670/216751200-795edc02-884e-45af-826a-058f6afc0936.png)

6. Afficher la solution.
![image](https://user-images.githubusercontent.com/111302670/216751217-df27d6ac-c4a5-4c7c-846c-2d7dcfe60635.png)

7. Manipulez vous-même
![image](https://user-images.githubusercontent.com/111302670/216752157-1d508c4e-4996-4ba1-90ab-a6c5e62073d9.png)

# Utilisation
Ouvrez et executez "labyrinthe.sln" sur visual studio

# Auteur
Xin Xu;

Yimin Chemen

# Support
Pour nous rejoindre, voux pouvez nous écrire à l'adresse suivante: e2194517@cmaisonneuve.qc.ca
