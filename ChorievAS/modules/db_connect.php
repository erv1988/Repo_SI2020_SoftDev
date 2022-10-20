<?php
$servername = "localhost";
$database = "cas_net";
$username = "cas";
$password = "cas.77.";
$conn = mysqli_connect($servername, $username, $password, $database);
if (!$conn) {
      die("Connection failed: " . "Не могу подключиться к базе");
}else{
	echo '<div style="display:none;">Подключился к базе</div>';
}
?>
