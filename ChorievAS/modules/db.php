<?php
// Подключаем библиотеку RedBeanPHP
require "rb-mysql.php";

// Подключаемся к БД
R::setup( 'mysql:host=localhost;dbname=cas_net',
        'root', '' );

// Проверка подключения к БД
if(!R::testConnection()) die('No DB connection!');

session_start(); // Создаем сессию для авторизации
?>