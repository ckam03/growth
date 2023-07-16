export async function getJournals() {
    const url = 'http://localhost:5207/journal'
    try {
        const response = await fetch(url, {
          method: "GET",
          mode: "cors",
        })

        if (!response.ok) {
            throw new Error('Could not fetch')
        }

        return await response.json()
      } catch (e) {
        console.log(e)
      }
}

export async function getJournalByName(name: string) {
  const url = `http://localhost:5207/journal/${name}`
  try {
      const response = await fetch(url, {
        method: "GET",
        mode: "cors",
      })

      if (!response.ok) {
          throw new Error('Could not fetch')
      }

      return await response.json()
    } catch (e) {
      console.log(e)
    }
}