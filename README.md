# B-Rush: 
## Lab 5: Save & Load System 

---

**Enlace del vídeo:** 
https://youtu.be/Xg_iSiYMsZo


## Objetivo
- tomar la mayor cantidad de pelotas evitando tocar la spike ball con el control derecho




Permite al jugador:

- Guardar el progreso actual  
- Cargar una partida previamente guardada  
- Reiniciar el juego eliminando el archivo de guardado  


---

## Sistema de Persistencia

Se implementó un sistema de guardado basado en:

- Serialización a JSON  
- Uso de ScriptableObjects para reconstrucción de datos  
- Manejo de archivos en `Application.persistentDataPath`  

---

## Datos guardados

Se creó una clase serializable (`GameSaveData`) que almacena:

- Inventario del jugador
- Score total 
- Total de pelotas recolectadas  
- Total de SpikeBalls recolectadas  
- Vidas actuales 
- Posición del jugador
- Fecha y hora del último guardado  

El archivo se guarda en:
Application.persistentDataPath/savegame.json


En caso que no exista el archivo:

- Se inicia una partida nueva  
- Se limpia el inventario  
- Se reinician las vidas  


---

## Tecnologías 

- Unity  
- C#  
- JSON (JsonUtility)  
- ScriptableObjects  
- XR Interaction Toolkit  

Assets: 
- https://assetstore.unity.com/packages/3d/props/ball-pack-446
- https://assetstore.unity.com/packages/3d/props/free-sport-balls-293937

