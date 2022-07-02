-- phpMyAdmin SQL Dump
-- version 5.1.3
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 09 May 2022, 23:01:50
-- Sunucu sürümü: 10.4.24-MariaDB
-- PHP Sürümü: 8.1.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `kitap_deposu`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `admin_sifre`
--

CREATE TABLE `admin_sifre` (
  `sifre` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Tablo döküm verisi `admin_sifre`
--

INSERT INTO `admin_sifre` (`sifre`) VALUES
('123456');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `aktif_siparisler`
--

CREATE TABLE `aktif_siparisler` (
  `SiparisNumara` int(11) NOT NULL,
  `Siparis` mediumtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kitaplar`
--

CREATE TABLE `kitaplar` (
  `Kitap_Numarasi` int(11) NOT NULL,
  `Kitap_Adi` varchar(50) DEFAULT NULL,
  `Kitap_Sayfa` int(11) DEFAULT NULL,
  `Kitap_Yazari` varchar(50) DEFAULT NULL,
  `Kitap_Stok` int(11) DEFAULT NULL,
  `Kitap_Bilgi` varchar(500) DEFAULT NULL,
  `Kitap_Fiyat` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Tablo döküm verisi `kitaplar`
--

INSERT INTO `kitaplar` (`Kitap_Numarasi`, `Kitap_Adi`, `Kitap_Sayfa`, `Kitap_Yazari`, `Kitap_Stok`, `Kitap_Bilgi`, `Kitap_Fiyat`) VALUES
(1, 'Homo Ludens', 255, 'Johan Huizinga', 14, 'Oyunun Kültürel İşlevi Üzerine Bir İnceleme.', 45),
(2, 'Dune', 700, 'Frank Herbert', 9, 'Korkumla yüzleşeceğim, üzerimden ve içimden geçmesine izin vereceğim. Korku geçip gittiği zaman, geçtiği yolu görmek için iç gözümü ona çevireceğim. Gittiği yerde hiçbir şey olmayacak; yalnızca ben kalacağım. Korkmamalıyım.', 75),
(3, 'Suç ve Ceza', 540, 'Dostoyevski', 11, 'Dünya klasikleri.', 40);

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `aktif_siparisler`
--
ALTER TABLE `aktif_siparisler`
  ADD PRIMARY KEY (`SiparisNumara`);

--
-- Tablo için indeksler `kitaplar`
--
ALTER TABLE `kitaplar`
  ADD PRIMARY KEY (`Kitap_Numarasi`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `aktif_siparisler`
--
ALTER TABLE `aktif_siparisler`
  MODIFY `SiparisNumara` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- Tablo için AUTO_INCREMENT değeri `kitaplar`
--
ALTER TABLE `kitaplar`
  MODIFY `Kitap_Numarasi` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
