package com.example.comercializadoragremlinsk.model

import com.google.gson.annotations.SerializedName

data class UserInfo(
    @SerializedName("correo") val correo: String?,
    @SerializedName("contrasena") val contrasena: String?,
)
