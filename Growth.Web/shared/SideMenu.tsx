import Image from "next/image"
import Journal from "../journal.png"
import Link from "next/link"
import { getJournals } from "@/features/journal/JournalService"
import { useQuery } from "@tanstack/react-query"
import { HomeIcon, ClipboardDocumentListIcon, PhotoIcon, 
         CalendarDaysIcon, Cog6ToothIcon, BackwardIcon } from "@heroicons/react/24/outline"
import { useRouter } from "next/router"

  type Journal = {
    id: string
    name: string
  }
export default function SideMenu() {
  const { data, isLoading } = useQuery({
    queryKey: ["journals"],
    queryFn: async () => {
      const data = await getJournals()
      return data as Journal[]
    },
  })

  if (isLoading) {
    return "loading..."
  }

  return (
    <div className="w-72 h-full bg-gray-800 text-gray-200 border border-gray-700">
      <h1 className="text-xl p-5 flex items-center space-x-4">
        <Image src={Journal} alt="icon" width={48} height={48} className="" />
        <span>Growth</span>
      </h1>
      <nav>
        <ul className="p-5 space-y-2">
          <li className="flex items-center space-x-4 hover:bg-blue-500 rounded-lg p-2">
            <HomeIcon className="w-7 h-7"/>
            <span>Today</span>
          </li>
          <li className="flex items-center space-x-4 hover:bg-blue-500 rounded-lg p-2">
            <ClipboardDocumentListIcon className="h-7 w-7" />
            <span>Notes</span>
          </li>
          <li className="flex items-center space-x-4 hover:bg-blue-500 rounded-lg p-2">
            <PhotoIcon className="h-7 w-7" />
            <span>Attachments</span>
          </li>
          <li className="flex items-center space-x-4 hover:bg-blue-500 rounded-lg p-2">
            <CalendarDaysIcon className="h-7 w-7" />
            <span>Calendar</span>
          </li>
          <li className="flex items-center space-x-4 hover:bg-blue-500 rounded-lg p-2">
            <Cog6ToothIcon className="h-7 w-7" />
            <span>Settings</span>
          </li>
        </ul>
        <ul className="p-5 space-y-4 mt-5">
          <li className="flex items-center font-semibold hover:bg-blue-500 rounded-lg p-2">
            <Link href={"/journal"}>
              <span>Journals</span>
            </Link>
          </li>
          {data?.map((journal: Journal) => {
            return (
              <li key={journal.id} className="px-6">
                <Link href={`/journal/${journal.name}`}>
                {journal.name}
                </Link>
              </li>
            )
          })}
        </ul>
      </nav>
    </div>
  )
}
