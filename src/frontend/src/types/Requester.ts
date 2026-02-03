import { AxiosError, type AxiosInstance, type AxiosRequestConfig } from 'axios'

interface AxiosParameters extends AxiosRequestConfig {
  onSuccess?: () => void
  onError?: () => void
  onFinish?: () => void
}

class Requester<T> {
  public isLoading: boolean = false
  public isError: boolean = false
  public isSuccess: boolean = false
  public response: T | undefined
  public errorObj: AxiosError | undefined
  private instance: AxiosInstance

  constructor(axiosInstance: AxiosInstance) {
    this.instance = axiosInstance
  }

  public request(params: AxiosParameters) {
    this.isLoading = true
    this.instance
      .request(params)
      .then((response) => {
        this.isError = false
        this.isSuccess = true

        this.response = response.data as T
        if (params.onSuccess) params.onSuccess()
      })
      .catch((error: AxiosError) => {
        this.isError = true
        this.isSuccess = true

        this.errorObj = error
        if (params.onError) params.onError()
      })
      .finally(() => {
        this.isLoading = false
        if (params.onFinish) params.onFinish()
      })
  }

  public static Create<T>(axiosInstance: AxiosInstance) {
    return new Requester<T>(axiosInstance)
  }
}

export default Requester
