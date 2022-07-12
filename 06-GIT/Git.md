# GIT
 
1. De las siguientes ¿Cual no es cierta? (1)
   1. Git por defecto ofrece una rama "master" ***<-- Correcta***
   2. Las operaciones "clone" de Git crean una instancia del repositorio
   3. Las operaciones "pull" copian los cambios de un repositorio local a un repositorio remoto
   4. git status te informa de los elementos "unstaged" del repositorio
   
2. Cuantas opciones existen en Git para integrar cambios de una rama a otra rama? (2)
   1. 1
   2. 3 
   3. 2 ***<-- Correcta***
   4. 4
   
3. Acerca del empleo de etiquetas Git para commits... (4)
   1. Pueden servir para gestionar versiones de release
   2. Pueden tener anotaciones
   3. Podemos poner etiquetas a commits pasados
   4. Todas son ciertas ***<-- Correcta***
   
4. Git trata los datos como (4)
   1. Archivos
   2. Carpetas
   3. Ninguna de las anteriores
   4. Snapshots ***<-- Correcta***
   
5. Si queremos incluir un mensaje para un commit concreto. Que comando deberiamos emplear? (1)
   1. git commit -m "Mensaje" ***<-- Correcta***
   2. git commit -a "Mensaje"
   3. git commit add . "Mensaje"
   4. git commit "Mensaje"
   
6. Para crear una version del repositorio que diverge del trabajo principal del proyecto en el que estamos trabajando usaremos... (2)
   1. git clone
   2. git fork
   3. git master
   4. git branch ***<-- Correcta***
   
7. Que diferencia hay entre el comando git stash y el comando git stash pop? (2)
   1. git stash elimina una commit historico del repositorio, mientras que git stash pop guarda los cambios en ramas diferentes
   2. git stas guarda los cambios en ramas diferentes, mientras que git stash pop elimina un commit del historico del repositorio
   3. git stash elimina el commit mas reciente, mientras que gist stash pop guarda los cambios actuales
   4. git stash crea una entrada stash, mientras que git stash pop trae el estado guardado al directorio de trabajo ***<-- Correcta***
   
8. Que conflictos pueden ocurrir cuando se realiza un push despues de un rebase? (4)
   1. La URL origin sera reseteada al valor por defecto
   2. La HEAD actual sera eliminada y no podremos reiniciarla
   3. Nada. Es practica habitual forzar un push despues de hacer un rebase
   4. La rama master podria tener cambios existentes sobreescritos ***<-- Correcta***

9. Que palabra usamos para referirnos al repositorio remoto del cual clonamos? (3)
   1. tag
   2. head
   3. origin ***<-- Correcta***
   4. index

10. Que comandos forzaran una sobreescritura de los archivos locales de la rama master? (4)
    1. git pull --all git reset --hard origin/master
    2. git pull -u origin master git reset --hard master
    3. git pull origin master git reset --hard origin/MiRamaActual ***<-- Correcta***
    4. git fetch --all git reset --hard origin/master

11. El comando git status te muestra informacion acerca de los commits (2)
    1. verdadero
    2. falso ***<-- Correcta***

12. Mientras estas modificando un archivo, de pronto te asignan la resolucion de un bug en otra rama. Como puedes, temporalmente guardar tu trabajo local sin tener que realizar un commit? (4)
    1. Usando git local-cache
    2. usando git hold
    3. no es posible. Hay que realizar un commit.
    4. Usando git stash ***<-- Correcta***

13. El comando git cherry-pick sirve para... (4)
    1.  Crear una etiqueta a un commit concreto
    2.  seleccionar un commit concreto y ubicar el HEAD en ese punto del historico del repositorio ***<-- Correcta***
    3.  Copiar un commit concreto a una rama nueva
    4.  Ninguna de las anteriores   

14. Cuando usamos el commando git log. Que opcion debemos añadir para limitar la informacion de los commits a partir de una fecha determinada? (1)
    1.  --since ***<-- Correcta***
    2.  --sinceWhen
    3.  --after
    4.  --afterDate

15. Acerca del archivo Gitignore. Que frase es falsa? (4)
    1.  Podemos tener varios gitignore en directorios distintos
    2.  Se trata de un archivo que indica que carpetas y extensiones de archivos deben mantenerse al margen del control de versiones y sus commits
    3.  Existen soluciones web que te permiten crear plantillas de Gitignore para distintos tipos de proyectos
    4.  todas son verdaderas ***<-- Correcta***

16. Como podemos eliminar archivos "untracked" del directorio de trabajo? (4)
    1.  git rm .
    2.  git checkout .
    3.  git reset HEAD
    4.  git clean -f ***<-- Correcta***

17. Si usamos el comando git add -A (1)
    1.  Todos los archivos nuevos y editados, en el directorio en el que trabajas, pasan a la etapa de "staged" ***<-- Correcta***
    2.  Unicamente los archivos nuevos, en el directorio en el que trabajas, pasan a la etapa de "staged"
    3.  Todos los archivos, del directorio en el que trabajas, pasan a la etapa de "staged" en orden alfabetico
    4.  Unicamente los archivos editados en el directorio en el que trabajas pasan a la etapa "staged"

18. Como podemos consolidar varios commits de un unico y coherente commit con la intencion de reestructurar el historico del repositorio? (1)
    1.  Usando git squash ***<-- Correcta***
    2.  usando git commit -a
    3.  usando git rebase
    4.  usando git push

19. Si usamos el comando git add *.js (1)
    1.  Estamos mandando todos los archivos Javascript (.js) a la etapa "staged" ***<-- Correcta***
    2.  Estamos realizando commit de todos los archivos JavaScript(.js) de la etapa "staged"
    3.  Nos dara un error
    4.  Ninguna de las anteriores

20. Internamente, Como gestiona git las ramas? (4)
    1.  Crea un array de ramas en el mismo repositorio ***<-- Correcta***
    2.  crea un log con los cambios del repositorio
    3.  crea un diccionario con los cambios del repositorio
    4.  crea un puntero al commit mas reciente para las nuevas ramas 