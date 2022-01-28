# Module 07 - Récursivité

## Compter en négatif

Écrivez une première fonction récursive qui affiche les nombres de -n à 0 à l'écran.

Écrivez une seconde fonction récursive qui affiche les nombres de 0 à -n. Si vous avez utilisé plus d'une paramètre, écrivez une variante à un paramètre.

## Division entière

Écrivez une fonction récursive qui calcule le reste de la division entière de deux nombres entiers sans utiliser le modulo.

## Suite de Fibonacci

La suite est définie de la façon suivante :

- Fibonacci(0) = 0
- Fibonacci(1) = 1
- Fibonacci(n) = Fibonacci(n - 1) + Fibonacci(n - 2)


Question 1 : écrivez la fonction Fibonacci en version récursive qui calcule une valeur de la suite de Fibonacci. FAIT

Avec cette fonction, calculez Fibonacci de 10 et validez que vous obtenez bien la valeur 55. FAIT

Question 2 : quelle est la complexité de votre fonction ? (Pour vous aider, dessinez l'arbre d'appels des fonctions)

- La complexité est de O(n2)

Question 3 : modifiez votre programme principal pour qu'il calcule les valeurs de Fibonacci de 1 à 40. Affichez les temps en Ticks et tracez la courbe sur Excel afin de valider la complexité que vous aviez trouvé.

 - La complexité trouvé à l'aide d'une grille excel confirme bien mon hypothèse de départ. En effet, il est possible de remarquer une évolution exponentielle du temps de traitement plus la suite de fibonacci est longue.

Question 3 : pourquoi la complexité est-elle aussi élevée ?

 - La complexité est tel puisqu'à chaque itération de la fonction récursive on double le nombre d'appel de la fonction de Fibonacci. J'ai remarqué en dressant un schéma une évolution qui dresse un portrait en arbre. Par exemple, au début la fonction est appelé 1 fois, ensuite 2 fois, ensuite 4 fois, ensuite 8 fois, ensuite 16 fois... Cela continue jusqu'au critère d'arrêt.

Question 4 : comment pourriez-vous améliorez votre fonction ? Réécrivez une version optimisée.

## Liste chaînée

Question 1 : écrivez une fonction récursive qui prend une liste chaînée générique et qui renvoie son nombre d'éléments en parcourant tous ses noeuds.

Question 2 : écrivez une fonction récursive qui prend une liste chaînée générique et qui renvoie la valeur la plus grande.

Question 3 : écrivez une fonction récursive qui prend une liste chaînée générique et une fonction lambda qui ne renvoie rien (Action<TypeElement>) et qui applique la fonction lambda sur chacun des noeuds.

Question 4 : réécrivez une nouvelle version des fonctions NombreDElements et Maximum en utilisant la fonction de parcours.

## Recherche

Question 1 : écrivez une fonction de recherche récursive qui prend un "IEnumerable" comme collection, une fonction lambda en paramètres et qui renvoie l'élément s'il est trouvé, la valeur par défaut sinon :

- La fonction lambda prend une valeur en paramètres et renvoie vrai si c'est la valeur à trouver, faux sinon.
- Votre fonction privée doit prendre un "IEnumerator" en paramètres ainsi que la fonction lambda.

Question 2 : écrivez une fonction récursive qui permet de compter le nombre d'éléments qui correspondent au critère d'une fonction lambda passée en paramètres :

- La fonction lambda prend une valeur en paramètres et renvoie vrai si c'est la valeur à trouver, faux sinon.
- Votre fonction privée doit prendre un "IEnumerator" en paramètres ainsi que la fonction lambda.
- Votre fonction renvoie le nombre d'occurrences

Question 3 : écrivez une fonction récursive qui permet de filtrer une collection d'éléments qui correspondent au critère d'une fonction lambda passée en paramètres :

- La fonction lambda prend une valeur en paramètres et renvoie vrai si c'est la valeur à trouver, faux sinon.
- Votre fonction privée doit prendre un "IEnumerator" en paramètres ainsi que la fonction lambda.
- Votre fonction renvoie une liste d'éléments du même type que les éléments de l'énumérateur.

## Recherche dichotomique

Écrivez une fonction de recherche dichotomique récursive qui prend un tableau d'éléments, une fonction lambda en paramètres et qui renvoie l'élément s'il est trouvé, la valeur par défaut sinon :

- La fonction lambda prend une valeur en paramètres et renvoie un entier correspondant à sa position par rapport à la valeur cherchée.
- Votre fonction privée doit prendre un tableau, les indices de début et de fin du sous-tableau ainsi que la fonction lambda.

## On se complique la vie pour l'exercice ! (Optionnel)

Réécrivez une nouvelle version de la fonction factorielle non optimisée sans utiliser la récursivité mais en la simulant. Pour cela, vous devez simuler la pile d'exécution en y mettant les paramètres sur la pile. Les appels sont simulées par une boucle "tant que".
