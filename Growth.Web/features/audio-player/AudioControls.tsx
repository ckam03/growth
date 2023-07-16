import {
  BackwardIcon,
  PauseIcon,
  PlayIcon,
  ForwardIcon,
} from "@heroicons/react/24/outline"

//take in props
//if playing, show the pause icon, otherwise play
interface audioControlsProps {
  state: boolean
}

export default function AudioControls({ state }: audioControlsProps) {
  return (
    <div>
      <div className="flex justify-center space-x-5">
        <BackwardIcon className="h-10 w-10 text-gray-200" />
        {state ? 
        <PlayIcon className="h-10 w-10 text-gray-200" /> : <PauseIcon className="h-10 w-10 text-gray-200" />}
        <ForwardIcon className="h-10 w-10 text-gray-200" />
      </div>
    </div>
  )
}
