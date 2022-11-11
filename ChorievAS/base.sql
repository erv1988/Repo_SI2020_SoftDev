-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Oct 20, 2022 at 06:55 PM
-- Server version: 5.7.33
-- PHP Version: 7.4.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cas_net`
--

-- --------------------------------------------------------

--
-- Table structure for table `registry`
--

CREATE TABLE `registry` (
  `id` int(10) NOT NULL,
  `name` char(25) COLLATE utf8mb4_unicode_ci NOT NULL,
  `value` char(25) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) UNSIGNED NOT NULL,
  `login` varchar(191) COLLATE utf8mb4_unicode_520_ci DEFAULT NULL,
  `email` varchar(191) COLLATE utf8mb4_unicode_520_ci DEFAULT NULL,
  `name` varchar(191) COLLATE utf8mb4_unicode_520_ci DEFAULT NULL,
  `family` varchar(191) COLLATE utf8mb4_unicode_520_ci DEFAULT NULL,
  `password` varchar(191) COLLATE utf8mb4_unicode_520_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_520_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `login`, `email`, `name`, `family`, `password`) VALUES
(1, 'cas', 'cas@cas.net', 'cas', 'casz', '$2y$10$PPU34Porb/8SUornwnvZbeyo5gdrcpjT1pgiVKTJ1mNzWKaYWira.'),
(2, 'admin', 'admin@admin.net', 'admin', 'adminze', '$2y$10$5fykob41MnJpqRjBS2VxlOOfdxipNyL7xhZtRRaBXame/f97SfU7u'),
(3, 'casyy', 'cas@casy.com', 'cas', 'cas', '$2y$10$I699mVLFZ0JxaR1Y7gaHF.fZs1OJ/C.Zu6Y6GGgCRA/pXUDg6.LwK'),
(6, 'demo', 'test@test.com', 'demo', 'demz', '$2y$10$UTqXq/khOAxrBIG00laovumbJ1o1nL/A8SqvCJgWDVLvzmfl5fmuK'),
(7, 'tester', 'test@tdemo.com', 'demmm', 'dmmz', '$2y$10$aLlj3h0knWy4P0Hb4MLA6ule17f2lFHtCYk2oPvmM/Pe4q7b0KmGm'),
(8, 'demo1', 'test@test1.com', 'demo1', 'demz1', '$2y$10$9K.jISiJ/dA1e1d9MWv6Hu2sQwt5pbdpYZdPxQzlsZlRoEH5yiI7G'),
(9, 'pash', 'pash@mash.su', 'sash', 'mash', '$2y$10$l.OZ5HWEZ3XmzS6WRnkIeuMA9JIrBQk0cCoj4qiAV4OG7LfRopaxC'),
(10, 'testoe', 'testoe@mail.com', 'catesto', 'testo', '$2y$10$aSEe9TpWAjRkWYbGBoQT/O0UR0L4rzjeTMROY9pugPXwlbGx/jJE6');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `registry`
--
ALTER TABLE `registry`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `registry`
--
ALTER TABLE `registry`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
