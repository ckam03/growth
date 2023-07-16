import Image from "next/image"
import AudioControls from "./AudioControls"
import Ocean from "../../ocean-waves.jpg"
import { useRef, useState } from "react";

export default function AudioPlayer() {
  const [trackIndex, setTrackIndex] = useState<number>(0);
  const [trackProgress, setTrackProgress] = useState<number>(0);
  const [isPlaying, setIsPlaying] = useState<boolean>(false);
  //const audioRef = useRef(new Audio(audioSrc));

  function prevTrack() {

  }

  function nextTrack() {

  }

  function pause() {
    
  }

  return (

<div className="max-w-xs h-80 border rounded-lg shadow bg-gray-800 border-gray-700">
    <a href="#">
    <Image src={Ocean} alt="icon" className="" />
    </a>
    <div className="p-5">
        <span className="flex items-center justify-center text-gray-200 py-4 text-semibold">Ocean Waves</span>
    {/* <AudioControls /> */}
    </div>
</div>
  )
}
