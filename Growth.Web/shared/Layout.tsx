import AudioPlayer from "@/features/audio-player/AudioPlayer"
import SideMenu from "./SideMenu"

interface LayoutProps {
  children: any
}

export default function Layout({ children }: LayoutProps) {
  return (
    <div className="w-screen h-screen relative">
      <main className="h-full flex bg-gray-900">
        <SideMenu />
        {children}
      </main>
    </div>
  )
}
