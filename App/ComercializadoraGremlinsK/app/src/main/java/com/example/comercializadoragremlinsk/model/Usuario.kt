package com.example.comercializadoragremlinsk.model

data class Usuario(
    val idUsuario: Int,
    val nombre: String,
    val habilitado: Boolean,
    val idRol: Int,
    val correo: String,
    val contrasena: String
)
