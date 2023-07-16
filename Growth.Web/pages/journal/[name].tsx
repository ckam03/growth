import { getJournalByName } from "@/features/journal/JournalService"
import { useQuery } from "@tanstack/react-query"
import { useRouter } from "next/router"
import { Journal, JournalEntry } from "@/types/types"

export default function Journal() {
  const router = useRouter()
  const { name } = router.query

  const { data, isLoading } = useQuery({
    queryKey: ["journal"],
    queryFn: async () => {
      const data = await getJournalByName(name as string)
      return data as Journal
    },
  })
  console.log(data)

  return (
    <div>
      {isLoading
        ? <span>Loading...</span>
        : data?.journalEntries.map((journalEntry: JournalEntry) => {
            return (
              <div
                className="text-gray-200 rounded-lg bg-gray-800 border border-gray-700 w-80 h-32 flex items-center"
                key={journalEntry.id}
              >
                <span className="text-xl">{journalEntry.date}</span>
                {journalEntry.entry}
              </div>
            )
          })}
    </div>
  )
}
