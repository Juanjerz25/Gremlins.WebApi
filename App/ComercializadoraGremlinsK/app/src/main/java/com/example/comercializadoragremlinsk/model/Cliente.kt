package com.example.comercializadoragremlinsk.model

data class Cliente(
    val idCliente : Int,
    val tipoDocumento : String,
    val numeroDocumento : String,
    val nombreCompleto : String,
    val direccion : String,
    val telefono : Int,
    val habilitado: Boolean
)
