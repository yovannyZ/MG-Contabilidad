USE [BD_COI01]
GO
ALTER PROCEDURE VERIFICAR_CONCEPTO_CUENTA
(@COD_MP CHAR(3),
@NRO_MP VARCHAR(15),
@COD_BANCO CHAR(4))
AS
SELECT A.COD_CPTO,B.DESC_CPTO,C.COD_AREA
FROM T_BANCO AS A  --,C.CUENTA_ENLACE 
LEFT JOIN MAESTRO_CONCEPTOS AS B ON A.COD_CPTO=B.COD_CPTO
LEFT JOIN CONCEPTO_CUENTA AS C ON A.COD_CPTO=C.COD_CPTO  
WHERE  
A.STATUS_TRANS='N '  AND 
--C.TIPO in ('I','O') AND 
COD_MP=@COD_MP AND 
NRO_MP=@NRO_MP AND 
COD_BANCO=@COD_BANCO AND 
A.COD_CPTO NOT IN(SELECT COD_CPTO FROM CONCEPTO_CUENTA)
--------------
