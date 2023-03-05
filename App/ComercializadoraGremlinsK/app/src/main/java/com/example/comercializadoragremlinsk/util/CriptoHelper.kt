package com.example.comercializadoragremlinsk.util

import android.util.Base64
import java.security.MessageDigest
import javax.crypto.Cipher
import javax.crypto.spec.SecretKeySpec

object CriptoHelper {

    val SEED = "NRC_127_7";

    /**
     * Funcion que encripta el mensaje y lo devuelve desencriptado
     */
    fun desencriptar(datos: String, pass: String): String{
        //
        var secretKey: SecretKeySpec = generateKey(pass)
        var cipher: Cipher = Cipher.getInstance("AES")
        // Modo desencriptación
        cipher.init(Cipher.DECRYPT_MODE, secretKey)

        // Array de bytes con datos descodificados
        var datosDescodificados: ByteArray = Base64.decode(datos, Base64.DEFAULT)
        // Array de bytes con datos desencriptados
        var datosDesenciptadosByte: ByteArray = cipher.doFinal(datosDescodificados)
        // Datos desencriptados en String
        var datosDesencriptadosString = String(datosDesenciptadosByte)

        return datosDesencriptadosString
    }

    /**
     * Función que encripta el mensaje y lo devuelve encriptado
     */
    fun encriptar(datos: String, pass: String): String {
        //
        var secretKey: SecretKeySpec = generateKey(pass)
        // Algoritmo de encriptación tipo AES
        var cipher: Cipher = Cipher.getInstance("AES")
        // Modo encriptación
        cipher.init(Cipher.ENCRYPT_MODE, secretKey)

        // Array de datos en bytes
        var datosEncriptadosBytes: ByteArray = cipher.doFinal(datos.toByteArray())
        // Devolverlo en Base64 y se convierte a String
        var datosEncriptadosString: String = Base64.encodeToString(datosEncriptadosBytes, Base64.DEFAULT)

        return datosEncriptadosString
    }

    /**
     * Genera una clave de tipo Sha-256 pasándole una contraseña de usuario
     */
    fun generateKey (pass: String): SecretKeySpec {
        // Genera el algoritmo seguro
        val sha: MessageDigest = MessageDigest.getInstance("SHA-256")
        // Pasar la clave a byte con el estándar UTF-8 en un array de bytes
        var key: ByteArray = pass.toByteArray(Charsets.UTF_8)
        // Llamamos al método digest que completa el cálculo del hash
        key = sha.digest(key)
        // Usamos estándar AES
        val secretKey = SecretKeySpec(key, "AES")

        return secretKey
    }

}