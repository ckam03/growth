export type Journal = {
  id: string
  name: string
  journalEntries: JournalEntry[]
}

export type JournalEntry = {
  id: string
  name: string
  entry: string
  date: string
}
