Algoritmo Gauss-Seidel,
# matrices, métodos iterativos
# Referencia: Chapra 11.2, p.310, pdf.334
#      Rodriguez 5.2 p.162
# ingresar iteramax si requiere más iteraciones

import numpy as np

def gauss_seidel(A,B,tolera,X,iteramax=100):
    tamano = np.shape(A)
    n = tamano[0]
    m = tamano[1]
    diferencia = np.ones(n, dtype=float)
    errado = np.max(diferencia)
    
    itera = 0
    while not(errado<=tolera or itera>iteramax):
        for i in range(0,n,1):
            nuevo = B[i]
            for j in range(0,m,1):
                if (i!=j): # excepto diagonal de A
                    nuevo = nuevo-A[i,j]*X[j]
            nuevo = nuevo/A[i,i]
            diferencia[i] = np.abs(nuevo-X[i])
            X[i] = nuevo
        errado = np.max(diferencia)
        itera = itera + 1
    # Vector en columna
    X = np.transpose([X])
    # No converge
    if (itera>iteramax):
        X=0
    return(X)
	
	