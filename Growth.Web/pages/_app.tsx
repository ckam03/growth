import Layout from "@/shared/Layout"
import "@/styles/globals.css"
import type { AppProps } from "next/app"
import { Inter } from "next/font/google"
import {
  useQuery,
  useMutation,
  useQueryClient,
  QueryClient,
  QueryClientProvider,
} from "@tanstack/react-query"

const inter = Inter({ subsets: ["latin"] })
const queryClient = new QueryClient()

export default function App({ Component, pageProps }: AppProps) {
  return (
    <QueryClientProvider client={queryClient}>
      <div className={inter.className}>
        <Layout>
          <Component {...pageProps} />
        </Layout>
      </div>
    </QueryClientProvider>
  )
}
