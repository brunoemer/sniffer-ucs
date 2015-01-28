Universidade de Caxias do Sul - Centro de Computação e Tecnologia da Informação 

Disciplina: INF0220A - Redes de Computadores Semestre: 2014/2
Professora: Maria de Fátima Webber do Prado Lima
Tarefa de programação
Trabalho individual ou em duplas
Data da apresentação do trabalho e da entrega da documentação: 08/07/2104
Desenvolver uma aplicação que capture o tráfego de rede, analise os segmentos da
camada de transporte e gere gráficos mostrando o diagrama dos segmentos recebidos e
enviados de uma determinada conexão TCP. Além disso, deverá realizar um diagnóstico para
identificar os segmentos perdidos e duplicados.
O programa poderá ser desenvolvido em qualquer linguagem de programação e poderá
utilizar as bibliotecas que a linguagem fornece, como por exemplo, a biblioteca de captura de
pacotes.
A aplicação deverá:
•
conter opções para iniciar a captura de pacotes e encerrar a captura de pacotes
•
ao encerrar a captura, a interface deverá mostrar um resumo de todos os pacotes TCP
capturados. No resumo dos pacotes capturados deve aparecer: número IP da máquina
origem, número IP da máquina destino, número da porta utilizada na máquina origem,
número da porta utilizada na máquina destino e uma breve descrição de cada pacote.
Esta descrição deve dizer se o segmento capturado se refere ao estabelecimento de
uma conexão, encerramento de uma conexão, restabelecimento de conexão, segmentos
de controle de conexão ou segmentos que contém dados do usuário
•
permitir que o usuário selecione um segmento TCP da amostra
•
ao selecionar qualquer segmento da amostra, a aplicação deverá solicitar se o usuário
deseja ver o diagrama de segmentos daquela conexão em específico
•
caso o usuário responda sim, a aplicação deverá montar um diagrama, contemplando
todos os segmentos capturados na amostra, referente a conexão selecionada
•
no diagrama, deverá ser mostrado os números IP e números de portas envolvidos na
conexão. Além disso, a cada segmento deverá ser mostrado o número de sequencia, o
número de reconhecimento, a quantidade de bytes que fazem parte deste segmento, o
tamanho da janela, bem como a representação gráfica que mostre qual o sentido da
comunicação (do IP x para o IP y , ou, do IP y para o IP x)
•
além de mostrar no diagrama os segmentos trocados entre as duas máquinas, será
necessário realizar um diagnóstico, que identifique onde está ocorrendo o
estabelecimento, encerramento ou reset da conexão (se houver na amostra), onde foi
localizado um segmento de dados perdidos ou o recebimento de dados duplicados.
