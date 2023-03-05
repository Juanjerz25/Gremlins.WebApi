package com.example.comercializadoragremlinsk.io

import com.example.comercializadoragremlinsk.io.response.ClientesResponse
import com.example.comercializadoragremlinsk.io.response.LoginResponse
import com.example.comercializadoragremlinsk.model.UserInfo
import retrofit2.Call
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.Headers
import retrofit2.http.POST
import retrofit2.http.Query

interface ApiService {

    @Headers("Content-Type: application/json")
    @POST(value = "Usuarios")
    fun postLogin(@Body userData: UserInfo):
            Call<LoginResponse>

    @Headers("Content-Type: application/json")
    @GET(value = "Clientes/GetClientes")
    fun getClientes():
            Call<ClientesResponse>

    companion object Factory{
        private const val BASE_URL = "https://gremlinswebapi.azurewebsites.net/api/"
        fun create():ApiService {
            val retrofit = Retrofit.Builder().baseUrl(BASE_URL).addConverterFactory(GsonConverterFactory.create()).build()
            return retrofit.create(ApiService::class.java)
        }
    }

}