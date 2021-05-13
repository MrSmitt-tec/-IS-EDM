# -IS-EDM
EN: Information System - Electronic Document management | RU: Информационная система - Электронный документооборот

PS(EN): "These are the first attempts in serious programming, the author is not responsible for your state after viewing how the project was implemented."


PS(RU): "Это первые попытки в серьёзном программирование, ответственность за ваше состояние после просмотра как был реализован проект автор не несёт."

-----------------------------------------------------------=EN=-----------------------------------------------------------

Okay, let's go(


Information System - Electronic Document management


Briefly: A certain client-server system for a certain organization "Bureau". It is assumed that it will back up working documentation, create backups of
operating systems, and connect via the VNC protocol . Management is carried out via the console on the server or the web interface.
The programming language so far is c#


What's new:

Clients:

v0.01 - before starting, specify the server ip-address and the port to which "packets" will be sent, receives the username @ computer_name and sends it to the server (console)

Server:

v0.02 - the server starts up and waits for receiving data from clients, connecting via TCP, displays the username@computer_name

v0.01 - gets a list of adapters and ip-addresses, but shows the numbering "crookedly" and outputs ipv6, you can specify a port (there is no port by default). There is a check for correct input 




-----------------------------------------------------------=RU=-----------------------------------------------------------

И так поехали(


Информационная система - Электронный документооборот


Кратко: Некая клиент серверная система для некой организации "Бюро". Предпологается что будет производить резервное копирование рабочей документации,
создание резервынх копий операционных систем, подключение по протоколу VNC . Управление осуществляеться через консоль на сервере или web-интерфейс. 
Язык программирования пока что c#


Что нового:

Клиенты:

v0.01 - перед запуском указывается ip адрес сервера и порт на который будут отправляться "пакеты", получает логин_пользователя@имя_компьютера и передаёт на сервер (консоль)

Сервер:

v0.02 - сервер запускается и ожидает приём данных от клиентов, соединение по TCP, выводит логин_пользователя@имя_компьютера

v0.01 - получает список адаптеров и ip адреса но "криво" показывает нумерацию и выводит ipv6, можно указать порт(по-умолчанию нет порта). Есть проверка на правильность ввода
