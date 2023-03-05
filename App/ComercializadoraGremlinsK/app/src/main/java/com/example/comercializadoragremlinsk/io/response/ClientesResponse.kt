package com.example.comercializadoragremlinsk.io.response

import com.example.comercializadoragremlinsk.model.Cliente
import com.google.gson.annotations.SerializedName

data class ClientesResponse(
    @SerializedName("successful") val successful: Boolean,
    @SerializedName("errorMessage") val errorMessage: String,
    @SerializedName("message") val message: String,
    @SerializedName("result") val result: ArrayList<Cliente>,
)
