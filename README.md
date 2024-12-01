# Prática em Laboratório UNITY - Pathfinding
 
Descrição das alterações:

Node.cs: Alterei a lista de neighbors pra guardar não só os nodes vizinhos, mas também as suas distâncias.

PriorityQueue.cs: Uma classe criada para dar prioridade a certos nodes, com base na distância do caminho, permitindo priorizar o caminho mais curto.

Pathfinder.cs: O método FindPath() agora utiliza o PriorityQueue, para econtrar o caminho mais eficiente.

MapController.cs: O código foi atualizado para funcionar com as alterações de Node.cs, além disso o LineRenderer agora mostra o caminho mais curto entre a origem e o destino.