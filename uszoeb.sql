-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Már 07. 10:52
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `uszoeb`
--
CREATE DATABASE IF NOT EXISTS `uszoeb` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `uszoeb`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `orszagok`
--
-- Létrehozva: 2024. Már 07. 08:07
-- Utolsó frissítés: 2024. Már 07. 08:05
--

DROP TABLE IF EXISTS `orszagok`;
CREATE TABLE `orszagok` (
  `id` int(11) NOT NULL,
  `nev` varchar(60) NOT NULL,
  `nobid` varchar(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- TÁBLA KAPCSOLATAI `orszagok`:
--

--
-- A tábla adatainak kiíratása `orszagok`
--

INSERT INTO `orszagok` (`id`, `nev`, `nobid`) VALUES
(1, 'Magyarország', 'HUN'),
(2, 'Nagy-Britannia', 'GBR');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szamok`
--
-- Létrehozva: 2024. Már 07. 08:00
-- Utolsó frissítés: 2024. Már 07. 08:05
--

DROP TABLE IF EXISTS `szamok`;
CREATE TABLE `szamok` (
  `id` int(11) NOT NULL,
  `nev` varchar(40) NOT NULL,
  `versenyzoid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- TÁBLA KAPCSOLATAI `szamok`:
--   `versenyzoid`
--       `versenyzok` -> `id`
--

--
-- A tábla adatainak kiíratása `szamok`
--

INSERT INTO `szamok` (`id`, `nev`, `versenyzoid`) VALUES
(1, '100m hát', 1),
(2, '200m hát', 1),
(3, '200m vegyes', 1),
(4, '200m vegyes', 2);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `versenyzok`
--
-- Létrehozva: 2024. Már 07. 08:07
-- Utolsó frissítés: 2024. Már 07. 09:49
--

DROP TABLE IF EXISTS `versenyzok`;
CREATE TABLE `versenyzok` (
  `id` int(11) NOT NULL,
  `nev` varchar(60) NOT NULL,
  `orszagid` int(11) NOT NULL,
  `nem` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- TÁBLA KAPCSOLATAI `versenyzok`:
--   `orszagid`
--       `orszagok` -> `id`
--

--
-- A tábla adatainak kiíratása `versenyzok`
--

INSERT INTO `versenyzok` (`id`, `nev`, `orszagid`, `nem`) VALUES
(1, 'Hosszú Katinka', 1, 'N'),
(2, 'Siobhan-Marie O’Connor', 2, 'N'),
(3, 'Késely Ajna', 1, 'N'),
(4, 'Telegdy Ádám', 1, 'F');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `orszagok`
--
ALTER TABLE `orszagok`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `nobid` (`nobid`);

--
-- A tábla indexei `szamok`
--
ALTER TABLE `szamok`
  ADD PRIMARY KEY (`id`),
  ADD KEY `versenyzoid` (`versenyzoid`);

--
-- A tábla indexei `versenyzok`
--
ALTER TABLE `versenyzok`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `nev` (`nev`),
  ADD KEY `orszagid` (`orszagid`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `orszagok`
--
ALTER TABLE `orszagok`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT a táblához `szamok`
--
ALTER TABLE `szamok`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT a táblához `versenyzok`
--
ALTER TABLE `versenyzok`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `szamok`
--
ALTER TABLE `szamok`
  ADD CONSTRAINT `szamok_ibfk_1` FOREIGN KEY (`versenyzoid`) REFERENCES `versenyzok` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `versenyzok`
--
ALTER TABLE `versenyzok`
  ADD CONSTRAINT `versenyzok_ibfk_1` FOREIGN KEY (`orszagid`) REFERENCES `orszagok` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;


--
-- Metaadat
--
USE `phpmyadmin`;

--
-- A(z) orszagok tábla metaadatai
--

--
-- A(z) szamok tábla metaadatai
--

--
-- A(z) versenyzok tábla metaadatai
--

--
-- A(z) uszoeb adatbázis metaadatai
--
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
