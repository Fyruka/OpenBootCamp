# Introducción al control de versiones

El control de versiones es una forma de conservar los cambios en varias carpetas por si hacemos un cambio poder volver hacia atras. Un control de versiones noe s una copia de seguridad. 

- Existen 3 sistemas de control de versiones desde hace mucho tiempo:
    - Locales
    - Centralizados
    - Distribuidos
  
---

## Locales

Un sistema local de carpetas donde cada cambio significativo lo guardamos como una copia del original en una carpeta con "dia y hora". Este sistema es horrible porque nos genera una cantidad de carpetas y sin poder ver que hicimos en cada cambio. Si dos trabajadores cambian el mismo archivo, tenemos que hablar y hacer el cambio manualmente, despues mandarlo a los compañeros. Jamas se usa este sistema. 

Hace muchos años se creo un sistema de control de versiones local llamado RCS que es el padre de los sistemas de control de versiones que conocemos actualmente. 

---

## Centralizados

Poco utilizados actualmente, existen dos controles de versiones centralizados:
- CVS -> Es una evolucion del RCS con muchas mejoras. Por excelencia se usaba la pagina **www.sourceforge.net**, aun existe esta pagina y aqui almacenaban los repositorios. 
- SUBVERISON (SVN) -> El mas utilizado durante mucho tiempo por ser mas sencillo su manejo. 

Al ser centralizado tenemos el codigo fuente y los cambios en un servidor. Esto genera el problema que no podemos trabajar de ninguna manera si el servidor esta caido, ya que todas las acciones las hace conectandose en remoto.

---

## Distribuidos

Son el sistema de control de versiones por excelencia, es el que se usa actualmente y aparentemente se va a quedar por muchos años. El mas utilizado actualmente es **GIT**, pero existen y existieron otros como **MERCURIAL** y **BAZAAR**.

La ventaja mas significativa en comparacion a los **Centralizados** es que no solo trabajan con un servidor, si no que tambien trabajan en local. Tenemos una copia completa del repositorio en nuestro ordenador, a diferencia de los centralizados que teniamos solo la ultima version. Esto nos permite trabajar en local, enviar modificaciones a nuestro repositorio local, y cuando tengamos conexion enviarlo al repositorio remoto. 

Con **GIT** tenemos una copia completa de todo el repositorio, trabajamos con la ultima version pero podemos acceder a los cambios que han habido, incluso podemos volver atras y recuperar archivos o fragmentos de codigo. Esto es posible gracias a que **GIT** crea una serie de referencias o punteros, y cuando hacemos algo con **GIT** los ficheros que nosotros vemos es una forma de verlo, ya que **GIT** internamente trabaja con las referencias o con un historial de confirmaciones. Y nos permite saltar de una confirmacion a otra, mas conocido como **COMMIT**.

